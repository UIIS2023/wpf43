   M S B A M L   `   `   `  ����G  CWpfAppPekara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WpfAppPekaraWpfAppPekara  5   	       WpfAppPekara.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WpfAppPekara     5   	     � Title$  Pekara��5   	   $	��450��6   $	��800��6%   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5
      $��Center=�6,   $��Center=�6I   $
��auto��6d   $
��auto��6r      
IsReadOnly$
 True��6      AlternatingRowBackground
 ��� �   CanUserAddRows$ False��5   3      SelectionUnit$ FullRow=�6J      SelectionMode$ Single=�6b   �� 5   
   $��Center=�6   $��30��62   $	��Top=�6?   $
��auto��6W    �� Orientation$ 
Horizontal=�6d   .+�5      �� -   5         ��Name$ btnPekar��5      $��Pekar��6'   $��30��67   $��75��6C   6N   �� 5      -   5        $ btnProizvod��5      $��Proizvod��6*   $
��Left=�6=   $��30��6X   $	��Top=�6d   $��75��6|   6�   �� 5      -   5        $ btnKupac��5      $��Kupac��6'   $
��Left=�67   $��30��6R   $	��Top=�6^   $��75��6v   6�   �� 5      -   5        $ btnKasir��5      $��Kasir��6'   $
��Left=�67   $��30��6R   $	��Top=�6^   $��75��6v   6�   �� 5      -   5        $ btnPorudzbina��5      $��
Porudzbina��6,   $
��Left=�6A   $��30��6\   $	��Top=�6h   $��75��6�   6�   �� 5      -   5        $ btnDobavljac��5      $��	Dobavljac��6+   $
��Left=�6?   $��30��6Z   $	��Top=�6f   $��75��6~   6�   �� 5      -   5        $ btnMaterijal��5      $��	Materijal��6+   $
��Left=�6?   $��30��6Z   $	��Top=�6f   $��75��6~   6�   �� 5      -	   5        $ 
btnNabavka��5      $��Nabavka��6)   $
��Left=�6;   $��30��6V   $	��Top=�6b   $��75��6z   6�   �� 5      -
   5        $ 	btnRecept��5      $��Recept��6(   $
��Left=�69   $��30��6T   $	��Top=�6`   $��75��6x   6�   5      �� 5   
   $��Center=�6   $��30��62   $��Bottom=�6?   $	��360��6Z   $ 
Horizontal=�6f   .+�5      �� -   5        $ btnDodaj��5      $��Dodaj��6'   $	��120��67   6C   �� 5      -   5        $ 	btnIzmeni��5      $��Izmeni��6(   $	��120��69   6E   �� 5      -   5        $ 	btnObrisi��5      $��Obriši��6(   $	��120��69   6E   5      5      5      