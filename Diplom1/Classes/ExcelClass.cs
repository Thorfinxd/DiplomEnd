using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom1.Classes
{
    static class ExcelClass
    {

        public static bool saveExcel(string filename, string sheetname, string[,] values)
        {
            //Публичный статичный метод saveExcel (Имя файлв, название листа, массив со значениями)
            try
            {
                FileStream file = new FileStream(filename, FileMode.Create, FileAccess.Write);//Открываем файловый поток
                                                                                              //(название файла, Режим - создание,
                                                                                              //Доступ - запись)
                XSSFWorkbook workbook = new XSSFWorkbook();//Создаем документ Excel
                ISheet sheet = workbook.CreateSheet(sheetname);//Создаем лист (название листа)

                for (int r = 0; r < values.GetLength(0); r++)
                { //Цикл по строкам
                    IRow row = sheet.CreateRow(r); //Создаем строку (номер строки)
                    for (int c = 0; c < values.GetLength(1); c++)
                    {//Цикл по столбцам
                        row.CreateCell(c).SetCellValue(values[r, c]); //Создаем ячейку (номер ячейки)
                                                                      //Задаем ее значение (значение)
                    }
                }
                workbook.Write(file);//Сохраняем файл (Поток)
                workbook.Close();//Закрываем файл

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static bool isCellNotEmpty(ICell cell)
        {
            return cell != null && !String.IsNullOrWhiteSpace(cell.ToString());//приватный метод, проверяющий, что ячейка не пустая
        }

        public static bool loadExcel(string filename, out DataTable table) //Публичный статичный метод импорта данных loadExcel
                                                                           //(Имя файла, out ТаблицаСРезультатом)
        {
            table = null; //изначально таблица пустая
            try
            {
                table = new DataTable(); //инициализируем новую таблицу данных
                FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);//Открываем файловый поток
                                                                                           //(название файла, режим - открытие,
                                                                                           //доступ - чтение)
                XSSFWorkbook sheets = new XSSFWorkbook(file);//Создаем документ Excel
                ISheet sheet = sheets.GetSheetAt(0); //Открываем нулевой лист (первоначальный)
                IRow row = sheet.GetRow(0);//читаем нулевую строку листа
                int columnscount = row.LastCellNum; //количество столбцов равно номеру последней ячейки в строке
                for (int c = 0; c < columnscount; c++) //перебираем столбцы
                {
                    if (isCellNotEmpty(row.GetCell(c))) //проверяется условие на пустую ячейку в строке
                    {
                        table.Columns.Add(row.GetCell(c).ToString().ToLower()); //Создаем в таблице колонки,
                                                                                //переводим название колонки в нижний регистр
                    }
                }
                for (int r = 1; r <= sheet.LastRowNum; r++)//перебираем строки листа
                {

                    IRow rowData = sheet.GetRow(r);//читаем каждую строку листа
                    if (rowData == null)
                        continue;
                    string[] rowarray = new string[columnscount];//создаем массив строк длиной с количество столбцов
                    for (int c = 0; c < columnscount; c++)//перебираем столбцы
                    {
                        if (isCellNotEmpty(rowData.GetCell(c)))//если ячейка в строке не пустая, то...
                        {
                            rowarray[c] = rowData.GetCell(c).ToString();//заполняем массив строкой в столбце(с)
                        }
                    }
                    table.Rows.Add(rowarray.ToArray());//добавляем в таблицу строку, заполняем ее данными массива
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }


}
