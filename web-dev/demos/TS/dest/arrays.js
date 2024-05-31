"use strict";
// Arrays in TS are very similar to arrays in JS but the difference now is that we specify the type
let numArray = [1, 2, 3, 4, 5];
// This will always be an array of numbers, besides that it functions as normal for a JS array
// We can apply our union types to this as well 
let stringOrBoolArray = [false, "string", true, 'another string'];
let array = [1, false, {}, []]; // Functions like a normal JS array
// Generics
// Generics are another way to define different types for things like arrays or other utility classes
// We won't use them too much here but just know they're a way to define the specific types that fall into your 
// structures. Defined inside of <>
let genericArray = [1, 2, 3, 4, 5]; // this is exactly the same as our numArray defined above
// Why would we use these? One, they're used with other utility types that don't support the original syntax
// As well as being used for certain OOP relationships (inheritance relationships)
// Arrays varies from TUPLES which are another structure added by TS
// Tuples are FIXED LENGTH arrays where the data type is specified at every position
let httpResponse;
// This is like a normal HTTP response with a status code, a list of headers, and the response body
httpResponse = [201, ['Content-Type-application/json', 'Authorization=username'], '{"username":"Jdoe"}'];
// Tuples are useful if you need to return multiple things out of a function. It allows you to create a fixed
// length structure that has the exact types you want at each position
