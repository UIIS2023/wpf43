   M S B A M L   `   `   `  ����G  CWpfAppPekara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfAppPekara.FormeWpfAppPekara.Forme  5   	   &     WpfAppPekara.Forme.FrmPorudzbina   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WpfAppPekara.Forme     5   	     � Title$  
Porudzbina��5   	   $	��367��6   $	��330��6)   .��5	      � .+�5   
   �� -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   
����+��
���� ��$
��Left=�6h   $��
69,262,0,0q�6�   $��75��6�   $	��Top=�6�   6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   
�������
���� ��$
��Left=�6a   $��180,262,0,0q�6|   $��75��6�   $	��Top=�6�   6�   �� 5   
   $��
Proizvod: ��6   $
��Left=�6&   $��	29,64,0,0q�6A   $	��Top=�6T    J� RenderTransformOrigin$ -1.035,-0.927&�6l   �� 5   
   -   5         ��Name$ 
cbProizvod��5      $
��Left=�6'   $��
158,65,0,0q�6B   $	��Top=�6V   $��23��6n   $	��120��6z    �� DisplayMemberPath$ naziv��6�    �� SelectedValuePath$ 
proizvodID��6�   �� 5   
   $��Kolicina proizvoda: ��6   $
��Left=�60   $��	29,95,0,0q�6K   $	��Top=�6^   $ -1.035,-0.927&�6v   �� 5   
   -   5         ��Name$ txtKolicina��5      $
��Left=�6'   $��
158,93,0,0q�6B    �� TextWrapping$
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $��23��6�   $	��120��6�   �� 5   
   $��Kupac: ��6   $
��Left=�6#   $��
29,121,0,0q�6>   $	��Top=�6R   $ -1.035,-0.927&�6j   �� 5   
   -   5        $ cbKupac��5      $
��Left=�6$   $��158,122,0,0q�6?   $	��Top=�6T   $��23��6l   $	��120��6x   $	 ime��6�   $ kupacID��6�   �� 5   
   $��Kasir: ��6   $
��Left=�6#   $��
29,151,0,0q�6>   $	��Top=�6R   $ -1.035,-0.927&�6j   �� 5   
   -   5        $ cbKasir��5      $
��Left=�6$   $��158,152,0,0q�6?   $	��Top=�6T   $��23��6l   $	��120��6x   $ prezime��6�   $ kasirID��6�   5      5      