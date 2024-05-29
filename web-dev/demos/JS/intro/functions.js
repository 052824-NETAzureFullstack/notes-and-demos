/*
Functions in JS behave very similarly to functions in other programming languages.

Recall that a function is just a block of repeatable code that often is used with varying parameters
*/

function simpleFunction(){
    // Any parameters go within the parantheses and the actual body of the function goes between the curly braces

    console.log("I'm inside a function!")
}

// Why don't we see anything print to the console?
// Just because we created the function doesn't mean it runs, we need to call it
simpleFunction();

// Now let's look at a function that takes in a parameter

function isEven(num){

    if (num % 2 == 0){
        return "Even"
    } else {
        return "Odd"
    }

}

console.log(isEven(5))
console.log(isEven(42))

// Default values
// In JS, you can provide a default value for a variable so the function can operate with a varying amount of parameters
// This is similar in concept to something called an overloaded method

function multiply(x, y = 1){
    return x * y
    // In this function y has a default value of 1 so if only one value is provided it returns the initial value but otherwise multiplies 
    // the numbers together
}

console.log(multiply(5, 7))
console.log(multiply(12))

// This is very similar to having 2 functions for the price of 1 since you can make it work in multiple scenarios


// Other things when it comes to functions
// Anonymous function -> function without a name, stored inside a variable
let anonFunction = function(x){
    return x / 2
}

anonFunction(4);

// Another thing that can be seen sometimes is called an IIFE (immediately invoked function expression)

// This is good for initializing values or creating a function at the top scope that only fires a single time and cannot be called again
(function(num){
    console.log("I'm in an immediately invoked function")
    console.log('My num is ' + num)
})(4);

// The function above will run a single time but cannot be run again

// Arrow functions 
// Functions with slightly different syntax, used in a variety of things, mainly for callback functions
// A callback function is a function that is passed to a different function as an argument
let arrowFunction = (z) => {
    console.log("Im in an arrow function!")
    console.log(z * z)
}

arrowFunction(3)