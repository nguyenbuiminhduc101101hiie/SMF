# SMF (TSA) — Phần mềm quản lý Freight Forwarding & Logistics (Windows)

> Ứng dụng desktop quản lý trọn vẹn nghiệp vụ của công ty giao nhận vận tải: Sales & báo giá, chứng từ hàng xuất/nhập (Sea, Air, Logistics, NVOCC), quản lý container, kho, đội xe, công nợ – thu chi và báo cáo quản trị cho ban giám đốc.

SMF đã được nhiều công ty forwarding sử dụng (mỗi khách hàng một database và bộ logo/mẫu in riêng). Tên assembly khi build: **`TSA.exe`**.

## 1. Hệ thống dùng để làm gì?

Một lô hàng đi qua nhiều bộ phận; SMF giúp tất cả cùng làm trên một dữ liệu:

```text
Sales báo giá → Booking → Chứng từ (tạo Ref/Job, HBL/MBL, Arrival Notice, Packing/Loading list)
   → Điều xe / kho / container → Đề nghị thanh toán, tạm ứng → Debit/Credit note
   → Hóa đơn, phiếu thu/chi, công nợ → Báo cáo lợi nhuận & KPIs
```

## 2. Các phân hệ (theo menu chính)

| Menu | Nội dung |
|---|---|
| **Sales** | Gửi báo giá, cơ sở dữ liệu khách hàng, booking, lợi nhuận lô hàng (P/L) theo Agency / Import / Export / Domestic / Rail / Truck / Customs / Oversea / Sea / Air, mã Sales, báo cáo Sales, Ship order |
| **Management Report (CEO)** | Báo cáo tuần theo Agent/Khách/Vendor, công nợ khách hàng & nhà cung cấp, SOA, lợi nhuận theo HB/L – MB/L (có/không VAT), target & thưởng Sales, báo cáo chi tiết thu/chi theo phí/container, sản lượng theo tuyến, Sales chart, booking report, theo dõi Bill – Tờ khai, KPIs |
| **Customer Service & Documentation** | Hàng nhập / xuất — **Air** và **Sea (FCL, LCL, Consol)**: tạo Ref/Job, chứng từ, sheet details, đề nghị thanh toán, theo dõi Bill – Tờ khai, Discharge/Loading/Packing list, phân bổ chi phí hàng Consol, import Job từ Excel, báo cáo trạng thái container hằng ngày |
| **Pricing** | Lịch tàu, Sea tariff (FCL/LCL nhập/xuất), Air tariff, biểu phí theo item, Local charges, import bảng báo giá cước, Tariff header |
| **Logistics** | Tạo Ref, chứng từ, biên bản bàn giao, kế hoạch điều xe, **quản lý nhiên liệu** (tạm ứng, nợ nhiên liệu lái xe, quyết toán nhiên liệu & lương lái xe), Cargo receipt |
| **NVOCC** | Chứng từ hàng nhập/xuất của hãng tàu NVOCC |
| **E.Q. Management** | Danh sách container, stock hằng ngày theo trạng thái (IFD, DCO, EMM, DSO, OFO, OEO, BFF), báo cáo tồn, cảnh báo |
| **Contract** | Hợp đồng giá bán, hợp đồng giá mua (định mức xe container) |
| **Warehouse** | Nhập kho, xuất kho, tồn kho |
| **List** | Danh mục: cảng, phí, terminal, hãng tàu, mặt hàng, thị trường, agent, khách hàng, xe container, rơ-moóc, kho / khu / dãy / vị trí |
| **Payment / Accounting** | Xuất hóa đơn VAT từ Debit note, hạn công nợ, bảng kê 01/GTGT, phiếu thu / phiếu chi (tạm thu, cược container), tổng hợp thu chi, sổ quỹ, khấu hao & chi phí phân bổ / sửa chữa, duyệt đề nghị thanh toán (Quản lý duyệt → Kế toán duyệt) |
| **Xuất sang phần mềm kế toán** | **MISA**, **Bravo**, **SAP**, **Smart Pro**, **Lemon**; xuất 511, 3331 |
| **Tools / System** | Phân quyền, phòng ban, người dùng, người dùng online, tiền tệ, tham số, đăng ký license, chỉ tiêu Sales, backup, xuất/nhập dữ liệu, tra cứu nâng cao, tìm container |

## 3. Công nghệ

| Hạng mục | Công nghệ |
|---|---|
| Ứng dụng | **VB.NET Windows Forms**, .NET Framework **4.8** |
| Database | SQL Server (ADO.NET, typed DataSet) |
| Giao diện | DevExpress WinForms v25.1 (Grid, Charts, Layout, RichEdit…), DevComponents DotNetBar |
| Báo cáo / in ấn | **Crystal Reports** (`*.rpt` — HBL, Debit/Credit, Arrival Notice, báo giá, phiếu thu chi…), MSChart |
| Office | Excel / Word Interop (xuất – nhập file Excel, mẫu Word) |
| Email | Microsoft Exchange Web Services |

## 4. Cấu trúc mã nguồn

```text
SMF.sln / SMF.vbproj      Solution & project (output: TSA.exe)
frmMain.vb                Form chính với toàn bộ menu
frm*.vb                   Các màn hình nghiệp vụ (nhập Bill, Debit/Credit, báo cáo, kế toán, kho…)
rpt*.rpt, Report*.rpt     Mẫu báo cáo Crystal Reports
*DataSet*.xsd             Typed DataSet cho báo cáo
UsrControl*.vb            User control dùng chung
Images/                   Icon, logo
sql/                      Script SQL nâng cấp database
docs/                     Tài liệu hướng dẫn (Tarif Detail…)
My Project/               Cấu hình ứng dụng (MainForm = frmMain)
```

## 5. Build & chạy

Yêu cầu:

- Visual Studio 2019/2022 với .NET Framework 4.8
- **DevExpress WinForms v25.1** (cần license)
- **SAP Crystal Reports runtime** cho Visual Studio
- Microsoft Office (Excel/Word) cho các chức năng xuất – nhập file
- SQL Server với database của khách hàng

Các bước:

1. Mở `SMF.sln`, restore các reference (DevExpress, Crystal Reports).
2. Cấu hình kết nối SQL Server cho môi trường của bạn (`app.config` / màn hình đăng nhập hệ thống).
3. Build (`Release`) và chạy `TSA.exe`; đăng nhập qua menu **System → Login**.

> ⚠️ Không commit chuỗi kết nối, mật khẩu database thật của khách hàng lên git.
