let currentTopic = [];
let currentIndex = 0;

// Hàm tải dữ liệu từ chủ đề đã chọn
function loadTopic(topicName) {
  currentTopic = [];
  currentIndex = 0;

  // Tìm dữ liệu của chủ đề trong HTML và lưu vào mảng
  const topicData = document.querySelectorAll(`#vocabulary-data [data-topic="${topicName}"] [data-word]`);
  topicData.forEach(item => {
    currentTopic.push({
      word: item.getAttribute("data-word"),
      meaning: item.getAttribute("data-meaning"),
      audio: item.getAttribute("data-audio")
    });
  });

  // Hiển thị từ đầu tiên trong chủ đề
  loadCard();
}

// Hiển thị từ hiện tại trong flashcard
function loadCard() {
  if (currentTopic.length > 0) {
    const currentWord = currentTopic[currentIndex];
    document.getElementById("english-word").textContent = currentWord.word;
    document.getElementById("meaning").textContent = currentWord.meaning;
    flashcard.classList.remove("flipped");
  }
}

// Lật thẻ và phát âm thanh khi nhấn vào flashcard
const flashcard = document.getElementById("flashcard");
flashcard.addEventListener("click", () => {
  flashcard.classList.toggle("flipped");
  playSound();
});

// Phát âm thanh cho từ hiện tại
function playSound() {
  const audioSrc = currentTopic[currentIndex].audio;
  const audio = new Audio(audioSrc);
  audio.play();
}

// Chuyển sang từ vựng tiếp theo
function nextCard() {
  currentIndex = (currentIndex + 1) % currentTopic.length;
  loadCard();
}
