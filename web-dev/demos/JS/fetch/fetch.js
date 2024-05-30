// Recall we need to add an event listener to the button

// This click event should call a function that sends out HTTP Request

let titleInput = document.getElementById('titleInput')
let bodyInput = document.getElementById('bodyInput')


async function createNewPost(){

    // Let's make an object to store the inputs
    let postInput = {
        title: titleInput.value,
        body:bodyInput.value
    }

    let data = await fetch('https://jsonplaceholder.typicode.com/posts', {
        method : "POST",
        headers : {
            'Content-Type' : 'application/json'
        },
        body: JSON.stringify(postInput)
        // Recall our body should be a JSON String, so we need to turn our JS Object into a JSON String
    })

    let responseBody = await data.json()
    console.log(responseBody)

    
}