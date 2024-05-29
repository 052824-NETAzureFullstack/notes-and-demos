/*
JavaScript has some interesting properties and if you spend a lot of time in strongly-typed languages it will start to seem a little 
strange in comparison, but a JS developer will know these quirks and be able to make full use of them while programming


Truthy/Falsy
Type Coercion
Loose vs Strict Equality
Hoisting
*/

// Before when we did an if/else statement we had an expression that evaluated to boolean true/false
// What happens if we just try this with a random variable

let str = ""

if (str){
    console.log("String is true")
} else {
    console.log("String is false")
}

// What is happening here?
// JS attempts to convert between the actual variable and the boolean datatype to determine if something is considered true or false.

/*
The main rule in determining whether something is truthy or falsy is very simple: "If it is not falsy, it is truthy"

Falsy Values (Values that evaluate to false in a conditional):
null,
undefined,
empty string,
0,
NaN (not a number),
false

When would this be useful?
What if we want to make sure someone has filled out an input field
*/

let usernameInput = "jonsmith"

if (usernameInput){
    console.log("Good to sign in")
} else {
    console.log("Please fill out username field")
}

console.log('------------------------')

// Under the hood this is doing something called Type Coercion, which is where JS will attempt to convert from one datatype to another
// if it deems it neccessary.

let x = "3" / 4

console.log(x)

// JS converts the string "3" to the number 3 so it can actually perform the division

// Generally this is useful but it can lead to some interesting bugs

console.log(true + true + true)

// JS will convert this to 1 + 1 + 1 resulting in 3

// With type coercion we can sometimes run into issues with equality

console.log("5" == 5)
// There are situations where this could be an issue, so JS has introduced two kinds of equality operators

// == vs ===
// == (loose equality) will check the values are the same but not the datatype
// === (strict quality) will check the values AND the the datatypes are the same
console.log("5" === 5)


// Hoisting
// So far everything in our JS file has executed from top to bottom (barring any control flow)
// JS does an interesting thing called Hoisting where it pull function and variable DELCARATIONS to the top of their respective scope
// and allows them to be used before being "declared"

toBeHoisted();


function toBeHoisted(){
    console.log("I'm a hoisted function!")
}


let z = 17

printNumber(z)

function printNumber(num){
    console.log(num)
}
