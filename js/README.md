JavaScript version of Lift Kata
============================

Note: the full description of this exercise is in the [top level README](https://github.com/emilybache/Lift-Kata).

Run the tests using npm:

	npm test

# Additional info

## Installation

Go to the root directory (where the `package.json` is located) and run:

```bash
npm install
```

## Running tests

Run the tests once:

```bash
npm test
```

Run the test and re-run them once a file changes:

```bash
npm run tdd
```

### What's included

* Mocha to run tests
* [Sinon JS](http://sinonjs.org/) for all stub, spy and mocking needs
* [Assertions using Chai]((http://chaijs.com/api/bdd)), extended with the
  [`sinon-chai` plugin](https://github.com/domenic/sinon-chai).
  * The Expect style is used by default,
  you can change to use `Should` instead, in `test/common.js`,
* [Approvals.NodeJS](https://github.com/approvals/Approvals.NodeJS) for approval testing.