// GOAL: We want the button to do something when it gets clicked

// Ideally this would make a call to some API but for now we'll be satisfied if we can print something
// to the console

let createNewUserButton = document.getElementById('createNewUserButton')
let usernameInput = document.getElementById('usernameInput')
let passwordInput = document.getElementById('passwordInput')

// Let's create a function to be executed whenever the button is clicked
function createNewUser(){
    // GOAL: Call this function when the button is clicked

    // console.log("The button was clicked!")

    // Let's find a way to grab the values stored in our input elements and print them as some object

    // To get the value of the input boxes, we'll simply use the value property associated with their variable
    let usernameValue = usernameInput.value
    let passwordValue = passwordInput.value

    // I can construct an object with these values so they're ready to ship off with an HTTP request later

    let user = {
        username: usernameValue,
        password: passwordValue
    }

    // Pretend to send an HTTP request
    console.log(user)
}

// Right now we have our button in a variable and a function to execute but we need to link them
// together using something called an event listener

/*
An event listener will allow our JS page to "listen" for a specific interaction with our elements and do 
some logic whenever a specific event occurs on the correct element
*/
createNewUserButton.addEventListener('click', createNewUser)


// Let's take a look at a different event, maybe a mouse over
function usernameMouseOver(){
    console.log("Username input was moused over!")
}


// Let's talk about maybe a little more sinister event listener
// We're going to make a simple keylogger for the password field

function printPressed(event){
    // This function will print the pressed key in the password field whenever someone enters a letter

    // We're set up now so that the printPressed function will run whenever we press a key BUT how do we
    // know which key?
    // console.log("A key was pressed")

    // To access the key that was pressed we need more information about the event that occurred
    /*
    The event object is an object that encapsulates everything about an event (things like what element
        it occurred on, more specific info about the interaction, coordinates)
    */

        console.log(`The key entered was: ${event.key}`)
}

passwordInput.addEventListener('keypress', printPressed)