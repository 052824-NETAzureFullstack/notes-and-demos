/*
DOM manipulation is the process of using JS to manipuilated or change/alter the Document Object Model (DOM)
*/

// GOAL: Create a representation for every user on the page
// Normally this information would be pulled from some API, not just hardcoded
let users = [
    {
        id: 1,
        name: "Bryan Serfozo",
        username: "bserf",
        email: "bryan.serfozo@revature.com"
    },
    {
        id: 2,
        name: "John Smith",
        username: "jsmith",
        email: "jsmith@example.com"
    },
    {
        id: 3,
        name: "Jane Doe",
        username: "jdoe",
        email: "jane.doe@sample.com"
    }
]

// To create some HTML for each user and store it inside our userContainer div we need to first locate the userContainer on the DOM

let userContainer = document.getElementById('userContainer')
// This lets me target the userContainer specifically by using its id, you can also select a variety of elements by using their class name,
// tag name, or any other CSS selector

// Now let's create a function that will update the userContainer

function populateUsers(users){
    // Inside of this function we'll append child elements to the userContainer

    for (user of users){
        // Inside of here we'll do some logic for each individual element in the users array

        // First thing we probably want to do is create a div to store all their info
        let uDiv = document.createElement('div')

        // Now we can start to add info to the div dynamically
        // We can do this is 2 ways, we can use the innerText attribute (used for manipulating the text in an element)
        // or we can use the innerHTML attribute which allows us to create child elements as well

        // uDiv.innerHTML = '<h2>' + user.name + '</h2>'

        /*
        Template Literals

        In ES6, they introduced template literals as a way to inject JS expressions and variables directly 
        into text in a nice concise manner. To inject a variable/expression you need to use `` for your string
        and then wrap your expression with ${}
        */

        uDiv.innerHTML = `
            <h2>${user.name}</h2>
            <p>Username: ${user.username}</p>
            <p>Email: ${user.email}</p>
        `


        // We can manipulate the element in different ways as well, one of the most important is getting/setting 
        // various attributes

        uDiv.setAttribute('class', 'user')
        uDiv.setAttribute('id', `user-${user.id}` ) // When the element is finished we should see id user-1




        userContainer.appendChild(uDiv)
    }
}

populateUsers(users)