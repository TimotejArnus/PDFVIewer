   M S B A M L   `   `   `  ����D  @PDFViewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PDFViewer	PDFViewer  5   	       PDFViewer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PDFViewer     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��400��6)   $	��400��65   $	��300��6E   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   6,   �� 5      $��1* �6   6*   �� 5      $
��Auto �6   6,   �� 5      $
��Auto �6   6,   .+�5   
   �� $��8q�6   $��0,1,0,0q�6!   .@�5      �� $��General��6   .��5      �� .+�5      �� $��
Full path:��6   � 5       � ColumnDefinitions 5      �� 5      $��1* �6/   �� 5      $
��Auto �6/   .+�5      �� -   5        $��TbFileFullPath��5   "      TextBoxStyle#��[  6c   �� 5      -   5        $��BtnFilePath��5   1   $��. . .��6!   $��Right=�6D   $��32��6`   $��4q�6k   $��1��6v   6�   5       �� 5"      $��Name:��6   �� 5$      -   5        $��
TbFileName��5$      ${�False��60   #��[  6B   �� 5&      $��Size:��6   �� 5'      -   5        $��
TbFileSize��5'      ${�False��60   #��[  6C   5)      5+      �� 5,      $��Printers��6   .��5-      �� .+�5.      �� $��Printer name:��6   �� 5/      -   5        $��cbPrinterName��5/        ComboBoxStyle#��[ 64   50      51      52      �� 54   
   -   5        $��RtbErrorLogger��54   #   $��1��6   $��4q�69   $y�Hidden=�6D   �� 56   
   -   5        $��
BtnPreview��56      $��2��6     ButtonStyle#��[ 6K   .��57      ��  �� Orientation$ 
Horizontal=�6   .+�58      �� $��Images/preview.png��6   $��24��64   $��24��6?   �� 59      $��Preview��6   $��4,0,0,0q�6+   $��Center=�6<   5:      5;      �� 5<   
   -   5        $��BtnPrint��5<      $��3��6   #��[ 6G   .��5=      �� $ 
Horizontal=�6   .+�5>      �� $��Images/print.png��6   $��24��62   $��24��6=   �� 5?      $��Print��6   $��8,0,0,0q�6)   $��Center=�6:   5@      5A      5C      5D      