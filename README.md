# Audacia.Random
### Random data generation library

![Build Status](https://dev.azure.com/audacia/Audacia/_apis/build/status/Audacia.Random?branchName=master)
[![NuGet](https://img.shields.io/nuget/v/Audacia.Random.svg)](https://www.nuget.org/packages/Audacia.Random)
[![CodeFactor](https://www.codefactor.io/repository/github/audaciaconsulting/audacia.random/badge)](https://www.codefactor.io/repository/github/audaciaconsulting/audacia.random)

## Extension Methods

There are a variety of extension methods available for the `System.Random` class. These are listed below:
- `.DateTime()`
- `.DateTime(DateTime from)`
- `.DateTime(DateTime to)`
- `.DateTime(DateTime from, DateTime to)`
- `.Enum<T>()`
- `.Element<T>(IEnumerable<T> items)`
- `.Elements<T>(IEnumerable<T> items, int count)`
- `.Elements<T>(IEnumerable<T> items, int min, int max)`
- `.Chars(int count)`
- `.Char()`
- `.Digits(int count)`
- `.MobileNumber(int count)`
- `.Digit()`
- `.Birthday()`
- `.PostCode()`
- `.Long(long max)`
- `.Long(long min, long max)`
- `.Birthday()`
- `.City()`
- `.County()`
- `.MaleForename()`
- `.FemaleForename()`
- `.Forename()`
- `.Surname()`
- `.Street()`
- `.Company()`
- `.EmailAddress()`

For any other object, the following extension methods are available:
- `.OrNull()`
- `.OrNull(int probability)`
- `.OrDefault()`
- `.OrDefault(int probability)`

## Base Data
The `Audacia.Random.Data` class exposes the collections of strings used for some of the extension methods. These are:
- `Cities`
- `Counties`
- `MaleNames`
- `FemaleNames`
- `Surnames`
- `Streets`
- `Companies`
