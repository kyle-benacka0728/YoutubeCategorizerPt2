<script lang="ts">
    // Runes mode reactive state - these are just the values, not objects!
    let query = $state('');
    let results = $state<string[]>([]);
    let loading = $state(false);
    let error = $state('');

    async function search() {
        // Access 'query' directly, not 'query.value'
        if (!query.trim()) {
            results = [];
            return;
        }

        error = '';
        results = [];
        loading = true;

        try {
            const res = await fetch(
                `http://localhost:5115/api/youtube/search?query=${encodeURIComponent(query)}`
            );

            if (!res.ok) throw new Error('Failed to fetch');

            const data: string[] = await res.json();
            results = data; // In Svelte 5, simple assignment works for arrays too!
        } catch (err) {
            console.error(err);
            error = 'Something went wrong. Try again.';
        } finally {
            loading = false;
        }
    }

    $effect(() => {
        if (query.trim() === '') {
            results = [];
        }
    });
</script>

<h1>Search YouTube</h1>

<input
        bind:value={query}
        placeholder="Search YouTube"
        onkeydown={(e) => e.key === 'Enter' && search()}
/>
<button onclick={search}>Search</button>

{#if error}
    <p style="color:red;">{error}</p>
{/if}

{#if loading}
    <p>Loading...</p>
{/if}

<ul>
    {#each results as r}
        <li class="video">🎬 {r}</li>
    {/each}
</ul>