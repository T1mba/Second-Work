<table style="width: 100%;">
  <tr>
    <td style="text-align: center; border: none;"> 
    Минестерство образования и науки РФ <br>
    ГБПОУ РМЭ "Йошкар-Олинский Технологический колледж </td>
  </tr>
  <tr>
    <td style="text-align: center; border: none; height: 15em;"><h2>Отчет по лабораторной работe<h2><br>
    По теме: "Поиск, сортировка."
    </td>
  </tr>
  <tr>
    <td style="text-align: right; border: none; height: 20em;">
      Разработал: Игимбаев Тимур<br/>
      Группа: И-21<br/>
      Проверил: Колесников Е.И.       
    </td>
  </tr>
  <tr>
    <td style="text-align: center; border: none; height: 5em;">
    г.Йошкар-Ола, 2021</td>
  </tr>
</table>

<div style="page-break-after: always;"></div>

# Цели и задачи:

1. Ознакомиться с информацией из [лекции](https://github.com/kolei/OAP/blob/master/articles/wpf_search_sort.md)
2. Создать поиск и сортировку

# Вывод 
1. В разметке окна в элементе WrapPanel добавил элемент для ввода текста - TextBox:
``` XML
<Label 
Content="искать" 
VerticalAlignment="Center"/>
<TextBox
Width="200"
VerticalAlignment="Center"
x:Name="SearchFilterTextBox" 
KeyUp="SearchFilter_KeyUp"/>
```
2. В коде окна создал переменную для хранения строки поиска 
```
private string SearchFilter = ""; 

private void SearchFilter_KeyUp(object sender, KeyEventArgs e)
{
SearchFilter = SearchFilterTextBox.Text;
Invalidate();
}
```
3. Доработал геттер списка книг:  
```
get {

var res = _BookList;
res = res.Where(c => SelectedJanr =="Все жанры" | c.Janr == SelectedJanr);

if (SearchFilter != "")
res = res.Where(c => c.NameAvtor.IndexOf(SearchFilter, StringComparison.OrdinalIgnoreCase) >= 0);
if (SortAsc) res = res.OrderBy(c => c.Year);
else res = res.OrderByDescending(c => c.Year);
return res;
```
4. Далее добавил радиокнопки в разметку для сортировки по году выхода книги:
```XML
<Label 
Content="Год выпуска:" 
VerticalAlignment="Center"/>
<RadioButton
GroupName="Year"
Tag="1"
Content="по возрастанию"
IsChecked="True"
Checked="RadioButton_Checked"
VerticalAlignment="Center"/>
<RadioButton
GroupName="Year"
Tag="2"
Content="по убыванию"
Checked="RadioButton_Checked"
VerticalAlignment="Center"/>
```
5. После чего, в коде добавил переменную для хранения варианта сортировки и обработчик смены варианта сортировки:
```
private bool SortAsc = true;

private void RadioButton_Checked(object sender, RoutedEventArgs e)
{
SortAsc = (sender as RadioButton).Tag.ToString() == "1";
Invalidate();
}
```

# Результат работы:
![rez](https://user-images.githubusercontent.com/78635110/118992595-75094080-b98d-11eb-90fa-f609ef4a3925.PNG)
