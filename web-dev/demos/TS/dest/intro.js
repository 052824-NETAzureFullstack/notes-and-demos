"use strict";
// This is our first TS file, note the extension is .ts not .js
// This file will need to be converted into JS before it can run on our JS enviroments (browser or NodeJS)
// TypeScript is a TYPED superset of JS
let sampleVariable = 'Hello World!';
// Note the different syntax here so the sampleVariable must always be a string
sampleVariable = "Another String";
/*
DataTypes in TS
String
Boolean
Number
Undefined
Null

Special Types:
Any
void
enums
tuples
arrays
never
*/
// Explicit Type Declaration
let x = 5;
console.log(x);
// Implicit type declaration
let bool = true;
// bool = "Something else" // Doesn't work because TS has implicitly declared this as a boolean
/*
Why do we care about this type safety stuff?

- Reducing the amount of fun "quirks" that JS has from various things like type coercion
- It's easier for working in group projects since the datatypes of the variables are explicit, meaning
    you don't have to go hunt down the current type/value
- Improved Intellisense
    - Intellisense is your IDE's ability to help you write code. Any time you see the list of methods available or
    it gives you some suggestion this is intellisense at work. This works better in strongly typed languages since
    your IDE can tell EXACTLY what methods are available because of the type
*/
// Any is the datatype in TS that allows a variable to function like JS
let y = true;
y = "Some string";
y = 6;
y = {};
// All of this is valid since y has any type
// Union types
/*
Sometimes there are situations where you need a variable to be one of 2 or more types. Maybe a variable needs
to be either a boolean or a number, how do we do this in TS? The answer is a union type
*/
let boolOrNumber = false;
boolOrNumber = 71;
// Void
// Void is used as the return type for a function that doesn't return anything
function sampleReturningFunction() {
    return 0;
}
let z = sampleReturningFunction();
function voidReturn(message) {
    console.log(message);
}
voidReturn('Hello World!');
// Let's imagine we're creating a function that takes in a bit more complex data type
function sendOfferLetter(emailObject) {
    // Goal of this function is to send off an email with an offer letter to a prospective employee
    console.log(`Hello ${emailObject.email}, we'd like to extend an offer of employement for the
     ${emailObject.position} position. The starting salary will be $ ${emailObject.salary}`);
}
let sampleEmailObject = {
    email: 'bryan.serfozo@revature.com',
    salary: 50000,
    position: 'Java Full Stack Trainer'
};
// Since the fields match up between the sampleEmailObject and the function parameters, I can pass the object
// to the function itself
sendOfferLetter(sampleEmailObject);
let wrongEmailObject = {
    email: 'ethan@revature.com',
    name: 'ethan',
    opportunity: 'Java Full Stack Trainer'
};
// This email type is now a custom type which I can assign variables to
let emailTypeAlias = {
    email: "",
    salary: 1234,
    position: ""
};
function sendOfferLetterWithTypeAlias(emailObject) {
}
// What if we don't need EVERY field. Some people have every field but not all. 
// Now I can create all of the people that I want and I can guarantee that they will fit this shape
let p1 = {
    firstName: "kaitlyn",
    lastName: "graves",
    age: 26,
    isMarried: false
};
let p2 = {
    firstName: 'John',
    lastName: 'Smith',
    isMarried: true
};
// We'll mainly use interfaces and a lot of the time this is used to define the shape of the data coming back from
// an api call. This way you can guarantee you have the appropriate fields in your frontend
// NEVER Datatype
// With luck, you'll never end up really using this but it does exist. This is used for a function that will
// never return a value (think of a function that always throws an exception)
function neverFunction() {
    throw new Error();
}
