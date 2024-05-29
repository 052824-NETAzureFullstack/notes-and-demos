/*
Arrays are the simplest datastructure inside of JavaScript and are similar to DS you might see elsewhere

Properties:
Arrays in JS can hold different types of variables.
Arrays are ordered/indexable
Arrays are dynamic in size
*/

let simpleArray = [1, "two", false, {property: "value"}, 1]

// We've already seen that we can iterate over this with the special for-of loop
// Arrays have some special methods inside of JS that we should know about

console.log(simpleArray[3])
// Since JS is a self-respecting Programming language it starts at 0, not 1 like some other languages

simpleArray[3] = 6

console.log(simpleArray)

// So since this dynamic in size we need a way to add a new value to the array. We do this with the push method
simpleArray.push(30)

console.log(simpleArray)

// If we want to do some logic for each element in the array we can use our for-of loop OR the forEach method
// NOTE: forEach takes a callback function. Recall a callback function is a function passed a separate function as a parameter

// simpleArray.forEach(function(x) {
//     console.log(x)
// })

simpleArray.forEach((x) => {
    console.log(x)
}) // This is an arrow function as a callback function

console.log('-----------------------')

// We can get the first or last element in the array and remove them with the shift and pop methods respectively
let x = simpleArray.shift() // removes the first element
let y = simpleArray.pop() // remove the last element

console.log(x)
console.log(y)
console.log(simpleArray)

console.log('--------------------------')

// Other array methods to consider
// Map and Filter
// Map is used to apply a function to every values in the array and return a value

let numArray = [1,2,3,4,5,6,7,8,9]

numArray = numArray.map((z) => {
    return z*z
})

console.log(numArray)

// Now filtering is a method that will take in the array and then based of some condition it will remove elements if neccessary 

numArray = numArray.filter((x) => {
    if (x % 3 == 0){
        return true
    } else {
        return false
    }
})

console.log(numArray)
