// Bài tập trắc nghiệm với giải thích
function checkQuiz() {
    const answer = document.querySelector('input[name="question1"]:checked');
    const result = document.getElementById("quiz-result");
    const explanation = document.getElementById("quiz-explanation");

    if (answer) {
        if (answer.value === "C") {
            result.textContent = "Correct!";
            result.style.color = "green";
            explanation.textContent = "Explanation: The audio discusses studying abroad, mentioning universities and student experiences.";
        } else {
            result.textContent = "Incorrect.";
            result.style.color = "red";
            explanation.textContent = "Explanation: The audio is about studying abroad, not traveling or cooking.";
        }
    } else {
        result.textContent = "Please select an answer.";
        explanation.textContent = "";
    }
}
// Bài tập điền từ với giải thích
function checkFillBlank() {
    const answer = document.getElementById("fill-blank").value.trim().toLowerCase();
    const result = document.getElementById("fill-result");
    const explanation = document.getElementById("fill-explanation");

    if (answer === "traveling") {
        result.textContent = "Correct!";
        result.style.color = "green";
        explanation.textContent = "Explanation: The speaker mentions 'traveling' as a relaxing activity in the audio.";
    } else {
        result.textContent = "Incorrect.";
        result.style.color = "red";
        explanation.textContent = "Explanation: The correct answer is 'traveling', as mentioned in the audio.";
    }
}
// Bài tập kéo thả với giải thích
let draggedItem = null;

document.querySelectorAll('.drag-item').forEach(item => {
    item.addEventListener('dragstart', () => draggedItem = item);
});

document.querySelectorAll('.drop-target').forEach(target => {
    target.addEventListener('dragover', e => e.preventDefault());
    target.addEventListener('drop', function () {
        if (draggedItem.id === "word1" || draggedItem.id === "word2" || draggedItem.id === "word3") {
            this.textContent = draggedItem.textContent;
        }
    });
});

function checkDragDrop() {
    const dropContent = document.getElementById("target1").textContent;
    const result = document.getElementById("drag-result");
    const explanation = document.getElementById("drag-explanation");

    if (dropContent === "Studying") {
        result.textContent = "Correct!";
        result.style.color = "green";
        explanation.textContent = "Explanation: The main topic of the audio is 'Studying', specifically studying abroad.";
    } else {
        result.textContent = "Incorrect.";
        result.style.color = "red";
        explanation.textContent = "Explanation: The correct answer is 'Studying', as that is the main topic of the audio.";
    }
}
