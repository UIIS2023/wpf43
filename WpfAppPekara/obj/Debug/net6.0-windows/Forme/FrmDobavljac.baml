   M S B A M L   `   `   `  ����G  CWpfAppPekara, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfAppPekara.FormeWpfAppPekara.Forme  5   	   %    WpfAppPekara.Forme.FrmDobavljac   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WpfAppPekara.Forme     5   	     � Title$  	Dobavljac��5   	   $	��314��6   $	��303��6(   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��290* �6   �� 5      $	��13* �6   .+�5   
   �� $��Ime: ��6   $
��Left=�6!   $��	29,30,0,0q�6<   $	��Top=�6O    J� RenderTransformOrigin$ -1.035,-0.927&�6g   $��26��6�   $��45��6�   �� 5   
   -   5         ��Name$ txtIme��5      $
��Left=�6"   $��
158,33,0,0q�6=    �� TextWrapping$
 Wrap=�6Q   $�� ��6e   $	��Top=�6m   $��23��6�   $	��120��6�   �� 5   
   $��Telefon ��6   $
��Left=�6$   $��	29,60,0,0q�6?   $	��Top=�6R   $ -1.035,-0.927&�6j   $��26��6�   $��91��6�   �� 5   
   -   5        $ 
txtTelefon��5      $
��Left=�6&   $��
158,63,0,0q�6A   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $��23��6�   $	��120��6�   �� 5   
   -   5         ��Name$ 
btnSacuvaj��5      $��Sacuvaj��6%   
����+��
���� ��$
��Left=�6h   $��
45,217,0,0q�6�   $��75��6�   $	��Top=�6�   $��20��6�   �� 5   
   -   5        $ 	btnOtkazi��5      $��Otkazi��6$   
�������
���� ��$
��Left=�6a   $��180,217,0,0q�6|   $��75��6�   $	��Top=�6�   $��20��6�   �� 5   
   $��	Nabavka: ��6   $
��Left=�6%   $��
29,140,0,0q�6@   $	��Top=�6T   $ -1.035,-0.927&�6l   $��26��6�   $��91��6�   �� 5   
   -   5         ��Name$ 	cbNabavka��5      $
��Left=�6&   $��158,143,0,0q�6A   $	��Top=�6V   $��23��6n   $	��120��6z    �� DisplayMemberPath$ 	nabavkaID��6�    �� SelectedValuePath$ 	nabavkaID��6�   5      5      