# Introduction to Jest Testing Framework

## What is Jest?

Jest is a JavaScript Testing Framework with a focus on simplicity. It works with projects using Babel, TypeScript, Node.js, React, Angular, Vue.js, and Svelte, and more. Jest aims to work out of the box and provide a zero-configuration experience.

## Getting Started with Jest

To get started with Jest, you need to have Node.js and npm (Node Package Manager) installed on your machine.

### Step 1: Install Node.js and npm

If you haven't installed Node.js and npm yet, you can download and install them from the [official Node.js website](https://nodejs.org/).

### Step 2: Initialize a new Node.js project

Navigate to your project directory in the terminal and run the following command to initialize a new Node.js project:

```bash
npm init -y
```

### Step 3: Install Jest

Next, install Jest as a development dependency by running the following command:

```bash
npm install jest
```

### Step 4: Configure Jest

You can configure Jest by adding a "test" script in your package.json file:

```json
{
  "scripts": {
    "test": "jest"
  }
}
```

Now, you can run Jest using the following command:

```bash
npm test
```

## Writing Your First Test

Create a new directory called tests in your project root, and inside this directory, create a file named example.test.js. Add the following code to this file:

```js
// example.test.js
function sum(a, b) {
  return a + b;
}

test('adds 1 + 2 to equal 3', () => {
  expect(sum(1, 2)).toBe(3);
});
```

In this example:

- We define a simple sum function that adds two numbers.
- We write a test case using Jest's test function.
- We use expect and toBe to assert that the result of sum(1, 2) is 3.

To run this test, use the command:

```bash
npm test
```

### Testing Asynchronous Code

Jest provides several ways to handle asynchronous code. Here are a few examples:

**Using Callbacks**

```js
// asyncCallback.test.js
function fetchData(callback) {
  setTimeout(() => {
    callback('peanut butter');
  }, 1000);
}

test('the data is peanut butter', done => {
  function callback(data) {
    try {
      expect(data).toBe('peanut butter');
      done();
    } catch (error) {
      done(error);
    }
  }

  fetchData(callback);
});

```

**Using Promises**

```js
// asyncPromise.test.js
function fetchData() {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve('peanut butter');
    }, 1000);
  });
}

test('the data is peanut butter', () => {
  return fetchData().then(data => {
    expect(data).toBe('peanut butter');
  });
});

```

**Using Async/Await**

```js
// asyncAwait.test.js
function fetchData() {
  return new Promise((resolve) => {
    setTimeout(() => {
      resolve('peanut butter');
    }, 1000);
  });
}

test('the data is peanut butter', async () => {
  const data = await fetchData();
  expect(data).toBe('peanut butter');
});
```

### Mocking

Jest also provides powerful tools for mocking to test components in isolation.

```js
// mockFunction.test.js
const myMock = jest.fn();
myMock.mockReturnValueOnce(true).mockReturnValueOnce(false);

test('mock function returns expected values', () => {
  expect(myMock()).toBe(true);
  expect(myMock()).toBe(false);
});

```