// This is a single line comment in JS

/*
    This is a multiline comment in JS


    This is our very first file with JS so let's test the basics

    What is JS?
    JavaScript(JS) is a programming language mainly used to provide functionality to our frontend pages. It primarily runs in the browser,
    but can be used for server-side development as well through a different runtime environment like Node.JS

    Notes/Features about JS: 
        High-Level Language: Being a high-level language means JS is further from machine code and more akin to human-readable syntax
        Dynamically and Loosely Typed: This is different from languages like Java where you must declare a type and stay that type. JS has
                the flexibility to allow you to not declare a type and have that type change whenever (a variable can start a string then change
                to a number then to a boolean with no issues, whereas a language like Java would freak out) NOTE: This doesn't mean JS doesn't
                have datatypes, they're just easy to change between
        Single-Threaded: Means there's one operation line, you cannot do concurrent processing with JS
        Interpreted Language: The code for JS gets compiled a single line at a time (Just-In-Time (JIT) compilation), this is what it means 
                for a language to be interpreted. What does it mean for a language to be compiled? The entire file must be compiled before
                the actual process can begin, menaing if there are any errors they must be resolved before anything can start, whereas an
                intepreted language can run until it gets to that error/exception.
        Multi-Paradigmed: Can be used in a variety of ways (OOP, Functional, Procedural, etc.)

    Whenever we start with a new programming language it's always good to return to the basics and understand the different syntax rules
*/

// How do we declare a variable?
var x = 10
// Notice that we don't add a datatype, JS will intepret that this is a number when the time comes
var message = "Hello World!"
var message2 = 'Hello World but in single quotes'
var message3 = `Hello World but in backticks`

// NOTICE: No semicolon at the end of the line. Generally it is not necessary to use any character to terminate the line (this is 
// different in a number of languages). Also notice there are 3 ways to declare strings, you can use "", '', ``

// How do we print things?
console.log(message)

// Let's validate some of the claims I made earlier about dynamic data types (the type of a variable changing at runtime)
x = "Ten"
x = true
x = false
x = {
    "name": 'bryan'
}

x = 10
// All of these are valid statements (no red squiggles) because the datatype can change dynamically

/*
NOTE: Var is technically outdated, we should use let and const now

What are Let and Const?
There are alternative ways to declare variables in JS. Old JS developers ran into issues using var since it has a global scope, long story
short it causes problems when using variables in a variety of scopes so let and const were introduced in ES6 to mitigate this problem

let -> used for standard variables (things you might want to change)
const -> used for assigning constant variables

What on earth is ES6?
JavaScript follows some standards laid out by ECMAScript and they have a variety of versions, an older one being ES6 which introduced let and
const
*/

let y = 5

y = "Five"

const z = 6; 

// z = "Six"
// Reassignment will cause an exception/error at runtime (this is not always the case like when a const variable is set to an object)

console.log(y)
console.log(z)


/*
Datatypes in JS

Just becuase Datatypes can change dynamically, doesn't mean there are no datatypes

Primitive types: string, boolean, number, undefined, null, BigInt and Symbol

Number: Any number, could be whole number or decimal, doesn't matter
Boolean: true/false
String: collection of characters/text
Undefined is declaring a variable but not giving it a value
Null is the absence of a value


Objects (JSON)
An Object in programming is the virtualization of some real world object. Generally in OOP languages they use classes as blueprints to 
construct them but really they just represent real world things with a variety of properties.

Person: name, age, height, weight, eye color
House: bedrooms, bathrooms, sq footage, address
User: username, password, email
Posts: userId, postId, title, body
*/

let samplePerson = {
    name: "Bryan Serfozo",
    age: 26,
    isMarried: false,
    email: "bryan.serfozo@revature.com"
}

// I can access all of the fields directly
console.log(samplePerson)
console.log(samplePerson.name)

samplePerson.name = 'Vincent'
console.log(samplePerson)