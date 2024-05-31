// This is a file we'll use with Jest to run a simple test

// Note the extensions being .test.js not just .js

/*
Jest is a testing framework for JS projects that excels in simplicity but has robust functionality and can provide
unit testing capabilities
*/

function sum(a, b){
    return a + b;
    // Imagine this is a very large, complex method, we want to validate that it works consistently so we'll 
    // write a test to manage that
}


test('adding 1 + 2 equals 3', () => {
    // This is the actual test body
    // We can do set up and tear down here but the main goal is to run the sum function and validate the result

    expect(sum(1,2)).toBe(3) // When I call sum(1,2) I expect 3 to be returned
})

// test('writing a test that does not pass', ()=>{
//     expect(sum(5,7)).toBe(10)
// })

/*
Normally when we do testing we'll have the tests cover the "business logic" portion of our applications (methods
    that perform validation, do some logic, have branching paths, etc). Hitting every edge case with our testing
    becomes very important since we want to make sure our methods work in every situation. Additionally this
    helps new developers joining the project. If they alter previously written methods, the new methods should
    still pass the tests and carry out the old functionality

    NOTE: Our test above is an example of "positive" testing, where we put in the appropriate terms and get
    the proper result. we should also do "negative" testing which says that if I put in improper terms I should 
    get the wrong result
*/

// Negative testing
test('3 + 2 should not equal 3', ()=> {
    expect(sum(3,2)).not.toBe(3)
})