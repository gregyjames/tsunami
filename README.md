[![.NET](https://github.com/gregyjames/tsunami/actions/workflows/dotnet.yml/badge.svg)](https://github.com/gregyjames/tsunami/actions/workflows/dotnet.yml)
![GitHub](https://img.shields.io/github/license/gregyjames/tsunami)
![GitHub issues](https://img.shields.io/github/issues/gregyjames/tsunami)
![Nuget](https://img.shields.io/nuget/v/Tsunami)
![Nuget](https://img.shields.io/nuget/dt/Tsunami)


| ![logo](./logo-small.png) | _tsunami_ |
| --- | ----------- |

A High Performance C# wrapper that allows you to get the benifts of SIMD Intrinsics on List\<T\>. 

### What does this do?
This library is a wrapper for System.Runtime.Intrensics and System.Numerics that allows you do get the performance benifits of SIMD instructions without having to worry about things like memory management, resizing inputs or dealing with the Vector<T> type. 

### Current supported vector operations:
- Add
- Max
- Min
- Multiply
- Subtract
- AndNot
- And
- Or
- Divide
- Xor
- SquareRoot

### Benchmarks
| Count     | Tsunami      | Normal       | Equal? | % Diff             |
|-----------|--------------|--------------|--------|--------------------|
| 10000     | 3.9621 ms    | 0.4234 ms    | True   | 89.31374776002625  |
| 100000    | 0.2125 ms    | 0.3279 ms    | True   | 35.19365660262276  |
| 1000000   | 2.1131 ms    | 3.2197 ms    | True   | 34.369661769730094 |
| 10000000  | 28.6489 ms   | 34.0691 ms   | True   | 15.909431126739474 |
| 100000000 | 686.2303 ms  | 485.0529 ms  | True   | 29.316309699527988 |
| 250000000 | 1409.1429 ms | 2354.5231 ms | True   | 40.15166383375045  |

### Code Example

    var x = Enumerable.Range(0, size).ToList();  
	var y = Enumerable.Range(0, size).ToList();  
	var res = Tsunami<int>.DoOperations(x, y, Operations.Add);  
Please look at the "TsunamiTester" project for more information.

### Supported Instruction Sets
- Generic
- AVX2
- NEON
- SSE3
- SSE41
- SSE42

### License
MIT License

Copyright (c) 2023 Greg James

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

