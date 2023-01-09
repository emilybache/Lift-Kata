# Lift Kata - PHP version

See the [top level readme](../README.md) for general information about this exercise. This is the PHP version of The
Lift Kata.

## Installation

The project uses:

- [PHP 8.0+](https://www.php.net/downloads.php)
- [Composer](https://getcomposer.org)

Recommended:

- [Git](https://git-scm.com/downloads)

Clone the repository

```sh
git clone git@github.com:emilybache/Lift-Kata.git
```

or

```shell script
git clone https://github.com/emilybache/Lift-Kata.git
```

Install all the dependencies using composer:

```sh
cd ./Lift-Kata/php
composer install
```

Run the tests:

```shell script
composer tests
```

## Dependencies

The project uses composer to install:

- [PHPUnit](https://phpunit.de/)
- [ApprovalTests.PHP](https://github.com/approvals/ApprovalTests.php)
- [PHPStan](https://github.com/phpstan/phpstan)
- [Easy Coding Standard (ECS)](https://github.com/symplify/easy-coding-standard)
- [PHP CodeSniffer](https://github.com/squizlabs/PHP_CodeSniffer/wiki)

## Folders

- `src`
    - Contains the **LiftSystem** Class which needs to be implemented.
    - Also, the **Call**, **Direction** and **Lift** Classes.
- `tests`
    - **LiftPrinter** Class Interface
    - **LiftAndDoorPrinter** Class which implements the **LiftPrinter** Interface
    - **SimpleLiftPrinter** Class which implements the **LiftPrinter** Interface
    - **LiftPrinterTest** Class uses the above printers and **ApprovalTests** to Test the **Lift**.
    - **LiftSystemPrinter** Class is the main printer which outputs the ASCII art representation of the lift
    - **LiftSystemTest** Class is the boiler-plate to test the **LiftSystem**
    - **CallTest** Class unit tests for **Call**
    - **LiftTest** Class unit tests for **Lift**
    - `approvals`
        - Contain the approved text files for each test method of **LiftPrinterTest** (these should not be changed)
        - New approval files will need to be created to test the **LiftSystem**

## Testing

PHPUnit is configured for testing, a composer script has been provided. To run the unit tests, from the root of the
project run:

```shell script
composer tests
```

On Windows a batch file has been created, like an alias on Linux/Mac (e.g. `alias pu="composer tests"`), the same
PHPUnit `composer tests` can be run:

```shell script
pu.bat
```

### Tests with Coverage Report

To run all test and generate a html coverage report run:

```shell script
composer test-coverage
```

The coverage report is created in /builds, it is best viewed by opening **index.html** in your browser.

The [XDebug](https://xdebug.org/download) extension is required for coverage report generating.

## Code Standard

Easy Coding Standard (ECS) is used to check for style and code standards,
**[PSR-12](https://www.php-fig.org/psr/psr-12/)** is used. Tip: Only periodically run ECS, when tests are green, to keep
the focus on writing tests, refactoring the code and adding new features.

### Check Code

To check code, but not fix errors:

```shell script
composer check-cs
``` 

On Windows a batch file has been created, like an alias on Linux/Mac (e.g. `alias cc="composer check-cs"`), the same
ECS `composer check-cs` can be run:

```shell script
cc.bat
```

### Fix Code

Many code fixes are automatically provided by ECS, if advised to run --fix, the following script can be run:

```shell script
composer fix-cs
```

On Windows a batch file has been created, like an alias on Linux/Mac (e.g. `alias fc="composer fix-cs"`), the same
ECS `composer fix-cs` can be run:

```shell script
fc.bat
```

## Static Analysis

PHPStan is used to run static analysis checks. As the code is constantly being refactored only run static analysis
checks once the chapter is complete. Tip: Only periodically run PHPStan, when tests are green, to keep the focus on
writing tests, refactoring the code and adding new features.

```shell script
composer phpstan
```

On Windows a batch file has been created, like an alias on Linux/Mac (e.g. `alias ps="composer phpstan"`), the same
PHPStan `composer phpstan` can be run:

```shell script
ps.bat
```

## Approval Tests

ApprovalTests can be used to compare the ASCII art output of the **LiftSystemTest**. Passing tests for
**LiftPrinterTest** have already been written, see [ApprovalTests.PHP](https://github.com/approvals/ApprovalTests.php)
for more information.

**Happy coding**!
