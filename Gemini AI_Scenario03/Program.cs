using System;

public class MonthDaysCalculatorAlt
{
    // --- Implementasi Enum untuk Indeks Tabel ---
    // Enum untuk merepresentasikan bulan-bulan.
    // Kita akan pastikan nilai enum sesuai dengan indeks array.
    public enum Month
    {
        // Secara default, January akan bernilai 0, February 1, dst.
        // Ini cocok untuk array yang berbasis 0.
        January = 0,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }

    // Tabel data (array) untuk menyimpan jumlah hari dalam setiap bulan.
    // Urutan elemen di array ini harus sesuai dengan urutan dan nilai enum Month.
    private static readonly int[] DaysInMonthNonLeapYearTable = new int[]
    {
        31, // Month.January (index 0)
        28, // Month.February (index 1) - Tahun non-kabisat
        31, // Month.March (index 2)
        30, // Month.April (index 3)
        31, // Month.May (index 4)
        30, // Month.June (index 5)
        31, // Month.July (index 6)
        31, // Month.August (index 7)
        30, // Month.September (index 8)
        31, // Month.October (index 9)
        30, // Month.November (index 10)
        31  // Month.December (index 11)
    };

    public static void Main(string[] args)
    {
        Console.WriteLine("--- Penghitung Jumlah Hari dalam Bulan (Tahun Non-Kabisat) ---");
        Console.WriteLine("Menggunakan Metode Table-Driven dengan Enum sebagai Indeks Array");

        // Contoh penggunaan dengan enum secara langsung:
        Console.WriteLine($"Jumlah hari di {Month.January}: {GetDaysInMonth(Month.January)} hari");
        Console.WriteLine($"Jumlah hari di {Month.February}: {GetDaysInMonth(Month.February)} hari");
        Console.WriteLine($"Jumlah hari di {Month.December}: {GetDaysInMonth(Month.December)} hari");

        Console.WriteLine("\n-------------------------------------------------");
        Console.WriteLine("Masukkan nama bulan (misal: January, February, dst.) untuk mencari jumlah hari:");
        string? inputMonthName = Console.ReadLine();

        // Mengonversi input string ke enum Month
        if (Enum.TryParse(inputMonthName, true, out Month parsedMonth))
        {
            // Memastikan nilai enum yang diparsing valid sebagai indeks
            if (IsValidMonthEnum(parsedMonth))
            {
                int days = GetDaysInMonth(parsedMonth);
                Console.WriteLine($"Jumlah hari di {parsedMonth} adalah: {days} hari.");
            }
            else
            {
                Console.WriteLine($"Nama bulan '{inputMonthName}' tidak valid atau di luar rentang yang diharapkan.");
            }
        }
        else
        {
            Console.WriteLine($"Nama bulan '{inputMonthName}' tidak dikenali. Harap masukkan nama bulan yang benar.");
        }

        Console.WriteLine("\n-------------------------------------------------");
        Console.WriteLine("Anda juga bisa memasukkan nomor bulan (1-12):");
        if (int.TryParse(Console.ReadLine(), out int monthNumber))
        {
            // Mengurangi 1 karena enum kita berbasis 0 dan input berbasis 1
            int enumValue = monthNumber - 1;

            if (Enum.IsDefined(typeof(Month), enumValue))
            {
                Month selectedMonth = (Month)enumValue; // Konversi int ke enum
                int days = GetDaysInMonth(selectedMonth);
                Console.WriteLine($"Jumlah hari di {selectedMonth} (bulan ke-{monthNumber}) adalah: {days} hari.");
            }
            else
            {
                Console.WriteLine($"Nomor bulan '{monthNumber}' tidak valid. Harap masukkan antara 1 dan 12.");
            }
        }
        else
        {
            Console.WriteLine("Input tidak valid. Harap masukkan angka.");
        }
    }

    /// <summary>
    /// Mengembalikan jumlah hari dalam bulan tertentu pada tahun non-kabisat
    /// dengan mengakses array menggunakan Enum sebagai indeks.
    /// </summary>
    /// <param name="month">Bulan yang ingin dicari jumlah harinya (tipe Enum Month).</param>
    /// <returns>Jumlah hari dalam bulan yang ditentukan.</returns>
    public static int GetDaysInMonth(Month month)
    {
        // Mengkonversi enum ke int untuk digunakan sebagai indeks array.
        // Ini adalah inti dari metode table-driven dengan Enum sebagai indeks.
        return DaysInMonthNonLeapYearTable[(int)month];
    }

    /// <summary>
    /// Memeriksa apakah nilai enum Month berada dalam rentang indeks yang valid untuk tabel.
    /// </summary>
    /// <param name="month">Nilai enum Month yang akan diperiksa.</param>
    /// <returns>True jika valid, false jika tidak.</returns>
    private static bool IsValidMonthEnum(Month month)
    {
        int monthInt = (int)month;
        return monthInt >= 0 && monthInt < DaysInMonthNonLeapYearTable.Length;
    }
}