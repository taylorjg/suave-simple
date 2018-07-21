const inputText = document.getElementById('inputText')
const outputText = document.getElementById('outputText')
const submitButton = document.getElementById('submitButton')

submitButton.addEventListener('click', function(e) {
  e.preventDefault()
  outputText.value = ''
  const xhr = new XMLHttpRequest()
  xhr.open('GET', '/api/toUpper/' + inputText.value)
  xhr.onreadystatechange = function() {
    if (xhr.readyState === 4 && xhr.status === 200) {
      outputText.value = xhr.responseText
    }
  }
  xhr.send()
})
