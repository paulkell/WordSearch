   M S B A M L   `   `   `  ����E  AWordSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WordSearch
WordSearch  5   	       WordSearch.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:WordSearch     5   	     � Title$  
WordSearch��5   	   $	��450��6   $	��800��6)   .��5	      � ���	#FFB4FF00.+�5
   
   �� $��10,46,0,338q�6   $
��Left=�6)   !Enter characters into text box:6e   �� 5   
   -   5         ��Name$ InputTextBox��5      $��173,46,0,343q�6(   $
��Left=�6]   $	��Top=�6x   $	��144��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��ResultsGrid��5         AutoGenerateColumns .  $��10,87,9.6,77q�6B      
IsReadOnly .   � ContextMenu 5      �� 5      .@�5      m� -   5        $��Add selected��5      65   m� 5      -   5        $��Remove selected��5      68   5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Word��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Word+6L     5      $ Length��6%   $ * 6P    65   �� *Length+6P     5      $ Order Found��6%   $ * 6T    6:   �� *Order+6T   5      �� 5   
   -   5        	 ��Name$	 StatusBlock��5      $��551,33,38,343q�6)   $��Right=�6@   Status: Awaiting Action6u   �� 5   
   -   5        
 ��Name$
 ComputeButton��5      $��341,0,345.6,10q�6@   $��Bottom=�6X   $��Center=�6s   $��53��6�   $	��107��6�   .��6�   	Compute6�   5      5      