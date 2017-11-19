# Documentation

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
- `.Surname()`
- `.Street()`
c.Company()`

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
