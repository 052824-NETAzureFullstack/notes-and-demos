// This is our first TS file, note the extension is .ts not .js

// This file will need to be converted into JS before it can run on our JS enviroments (browser or NodeJS)

// TypeScript is a TYPED superset of JS

let sampleVariable : string = 'Hello World!'

// Note the different syntax here so the sampleVariable must always be a string

sampleVariable = "Another String"

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
let x : number = 5;

console.log(x)

// Implicit type declaration

let bool = true

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
let y : any = true;

y = "Some string"

y = 6

y = {}

// All of this is valid since y has any type

// Union types
/*
Sometimes there are situations where you need a variable to be one of 2 or more types. Maybe a variable needs
to be either a boolean or a number, how do we do this in TS? The answer is a union type
*/

let boolOrNumber: boolean | number = false

boolOrNumber = 71

// Void
// Void is used as the return type for a function that doesn't return anything

function sampleReturningFunction() : number{
    return 0;
}

let z = sampleReturningFunction();

function voidReturn(message: string) : void{
    console.log(message)
}

voidReturn('Hello World!')
