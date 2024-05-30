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

// populateUsers(users)



//PROMISES

/*
Promises are an object in JS that act as a placeholder for a future value. Most async functions return them
implicitly so knowing how to work with them is important. We can construct our promise using the constuctor
and providing the appropriate callback functions
*/

let promise = new Promise(function (resolve, reject) {
    // This is the inside of a promise. We won't see them like this normally, but for demonstration we'll look
    // at it like this

    let x = 5
    let y = 3

    if (x >= y){
        resolve(x)
    } else {
        reject(x)
    }
})

// Once a promise exists (doesn't matter if you made it or it came from somewhere else) you chain consumer functions
// onto it

// then() is a function that takes a callback function and executes when the promise resolves only
promise
    .then((x) => x = x * 2) // State of x at this point is 10
    .then((x) => console.log(x))
    


/*
There are a couple of consumer functions to be aware of:
 then() is called when the promise resolves
 catch() is called when the promise rejects
 finally() is called after either a resolve or a rejection
*/

promise
    .then(() => console.log("We resolved!"))
    .catch(() => console.log("There was an error!"))
    .finally(() => console.log("This happens no matter what!"))

/*
This might seem really confusing and ethereal right now, but it'll make a little more sense with a concrete example

To get the info for our users, instead of using the hardcoded list above, let's try to make an API call
using an HTTP Request

To do this we'll use the Fetch API which is a built in tool in JS that allows to send customized HTTP requests
and parse the response as necessary. It was introduced as an alternative to something called AJAX, which was a 
more syntactically diffult way to send HTTP Requests
*/

let data = fetch('https://jsonplaceholder.typicode.com/users')

// A regular fetch call like this sends a GET request by default, we'll look to see how this changes later

// The information will come back from the API as a JSON (JavaScript Object Notation) string, we need to turn this
// string into a JS object that we can work with. To do this, the fetch API has the built in .json() method

data
    .then((data) => data.json()) // This step turns the string into an actual JS object
    .then ((response) => populateUsers(response))
    .catch((error) => console.log("There was an error in our fetch request!"))