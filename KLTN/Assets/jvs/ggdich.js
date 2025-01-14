async function translateText() {
    try {
        const inputText = document.getElementById('inputText').value;
        const language = document.getElementById('languageSelect').value;
        const targetLanguage = language === 'en' ? 'vi' : 'en';

        const response = await fetch(`https://translation.googleapis.com/language/translate/v2?key=YOUR_API_KEY`, {
            method: 'POST',
            body: JSON.stringify({
                q: inputText,
                source: language,
                target: targetLanguage,
                format: 'text'
            }),
            headers: {
        'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();
        const translatedText = data.data.translations[0].translatedText;
        document.getElementById('outputText').innerText = translatedText;
    } catch (error) {
        console.error('Error during translation:', error);
        document.getElementById('outputText').innerText = 'An error occurred during translation. Please try again.';
    }
}


### Notes
1. **API Key**: Replace `YOUR_API_KEY` with your actual API key from the translation service you are using.
2. **Styling**: Adjust the styling as needed to match the rest of your website.
3. **Error Handling**: Add error handling to manage cases where the translation API fails or returns an error.

This will create a simple translation dictionary tool on your page that allows users to translate text between English and Vietnamese.