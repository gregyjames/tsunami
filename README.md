[![.NET](https://github.com/gregyjames/tsunami/actions/workflows/dotnet.yml/badge.svg)](https://github.com/gregyjames/tsunami/actions/workflows/dotnet.yml)

<table style="border-collapse: collapse; border: none;">
  <tr style="border: none;">
    <td style="border: none;">
      <img src="https://github.com/gregyjames/tsunami/blob/02014eaf0661afb99797a14633429f02f1a51647/img/logo-modified.png" width="100"/>
    </td>
    <td style="border: none;">
      <h1><em>tsunami</em></h1>
    </td>
  </tr>
</table>

A C# wrapper for working with System.Vector for SIMD Intrinsics. 

### Current supported vector operations:
 - Add
 - Subtract
 - Multiply
 - Min
 - Max

### Code Example

    var x = Enumerable.Range(0, size).ToList();  
	var y = Enumerable.Range(0, size).ToList();  
	var res = Tsunami<int>.DoOperations(x, y, Operations.Add);  
Please look at the "TsunamiTester" project for more information.


