# Make some API for the project

## TL;DR

We make two API :
 - public station API is what the consumer will see
 - private station API

## Tasks
 - [ ] Choose langage and framework
 - [ ] Create public API
 - [ ] Create private API

## Requirement
 - [ ] API should be available as container
 - [ ] API should follow SOLID principe
 - [ ] API should have unit test, integration test, and follow TDD

## Why two API ?

Because purpose and lifecycle of these API are not the same

Consumer want simple API, with very long lifecycle.

So you need no hide the complexity of your internal business, infrastructure, data structure and so.

Once something is on the public API you have some moral obligation to ensure backward compatibility

Maybe you will have to adapt for a new customer with specific need, without duplicating business logic.

Public API :
 - Have long lifecycle
 - Ensure backward complexity
 - Don't handle business logic
 - Can call multiple API
 - Hide your private endpoint
 - Can handle security, rate limiting, authentication
 
Private API :
 - Can have short lifecycle, and frequent update
 - Should have a single responsibility / Domain
 - Handle business logic

## Why SOLID ? Unit Test ? TDD ?

Because we want at least have unit test on our business requirement, SOLID https://en.wikipedia.org/wiki/SOLID is a good practice to follow.

Dependency Injection (DI) to be able to mock our data.

Single Responsibility to have short and simple test to write.

You should know and be able to do Test Driven Development (TDD).

But you should always adapt to the context : 
 - Will an error cost you a lot of time / money ?
 - Is your API critical or can be down few hours or days ?
 - What will happed if an error is only discovered after weeks (for exemple by the invoicing team) ?
 - Will you be able to recover corrupted or wrong data ?
 - Is there an easy way to rollback ?
 - ...

An error will coast you time or money, the fastest fix is also the cheapest.

You can have zero test in your app, but it should be mandatory to be able to quickly add one.