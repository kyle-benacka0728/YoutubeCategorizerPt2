const { chromium } = require('playwright');

(async () => {
    const query = process.argv[2];

    const browser = await chromium.launch();
    const page = await browser.newPage();

    await page.goto(`https://www.youtube.com/results?search_query=${query}`);

    await page.waitForSelector('#video-title');

    const titles = await page.$$eval('#video-title', els =>
        els.slice(0, 5).map(e => e.textContent.trim())
    );

    console.log(JSON.stringify(titles));

    await browser.close();
})();