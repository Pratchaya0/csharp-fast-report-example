# FastReport กับ C# .NET 6

## 🎯 แนะนำ FastReport
```sh
 git clone -b starter https://github.com/Pratchaya0/csharp-fast-report-example.git
```
- Import .bacpac file
- Reverse engineer
- Cooking


## 🎯 แนะนำ FastReport
FastReport เป็นเครื่องมือสร้างรายงานที่ทรงพลัง ใช้งานง่าย และสามารถใช้ร่วมกับแอปพลิเคชัน .NET 6 ได้อย่างราบรื่น รองรับการแสดงผลข้อมูลแบบไดนามิกและการส่งออกรายงานไปยังหลายรูปแบบ เช่น PDF, Excel, และ Word

## 🚀 การติดตั้ง FastReport
ติดตั้งผ่าน NuGet โดยใช้คำสั่งนี้:

```sh
 dotnet add package FastReport.Net
```

หลังจากติดตั้งแล้ว ให้ตรวจสอบว่าโปรเจกต์ของคุณมีการตั้งค่าตรงกับ .NET 6

## 🛠 ออกแบบรายงานด้วย FastReport Designer
1. เปิด FastReport Designer และสร้างรายงานใหม่
2. เพิ่มองค์ประกอบ เช่น ข้อความ, รูปภาพ, ตาราง และ Data Bands
3. เชื่อมต่อแหล่งข้อมูล เช่น SQL, JSON หรือ XML

FastReport มี UI ที่ช่วยให้คุณออกแบบรายงานได้สะดวก

## 📄 โหลดและแสดงผลรายงานใน C#

```csharp
using FastReport;
var report = new Report();
report.Load("report.frx");
report.Show();
```

หากต้องการใช้ข้อมูลจากฐานข้อมูล:

```csharp
report.RegisterData(dataSet, "MyData");
```

## 📤 ส่งออกรายงานเป็น PDF

```csharp
report.Prepare();
report.Export(new FastReport.Export.Pdf.PDFExport(), "output.pdf");
```

สามารถส่งออกเป็น Excel, Word หรือ HTML ได้เช่นกัน

## ⚡ Background Processing สำหรับรายงานใหญ่
หากรายงานใช้เวลานาน ควรใช้ Background Processing เพื่อไม่ให้กระทบ UI

```csharp
using System;
using System.Threading.Tasks;
using FastReport;
using FastReport.Export.Pdf;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("กำลังสร้างรายงาน...");
        await Task.Run(() => GenerateReport());
        Console.WriteLine("สร้างรายงานเสร็จแล้ว!");
    }

    static void GenerateReport()
    {
        Report report = new Report();
        report.Load("report.frx");
        report.Prepare();
        report.Export(new PDFExport(), "output.pdf");
        report.Dispose();
    }
}
```

## 📚 แหล่งข้อมูลเพิ่มเติม
- [FastReport Documentation](https://www.fast-report.com/en/product/fast-report-net/)
- [ตัวอย่างโค้ดบน GitHub](https://github.com/FastReports)

หากมีข้อสงสัยหรืออยากแชร์ประสบการณ์ คอมเมนต์ได้เลย! 🚀

