   M S B A M L   `   `   `  ����F  BFactroyDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:FactroyDemoFactroyDemo  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      @ <Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null,"clr-namespace:Model;assembly=ModelModel 5	          FactroyDemo.UserControl1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:FactroyDemo     5      ;assembly&clr-namespace:System;assembly=mscorlib     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .Model"clr-namespace:Model;assembly=Model  5	      ���	#FFEAE5E5.��5      � .+�5   
   �   � RowDefinitions  5      �� 5      $
��Auto �6    �� 5      $��* �6    �� 5      $
��Auto �6    .+�5*      �� $��0��6   .+�5+      �� -   5         ��Name$ Title��5+   �   $��3q�6   $��20(�6'   $
��Bold"�65   $��Center=�6H   $��Center=�6e   $��yongho��6�   5-      &   System.Windows.Controls.DataGrid  5/      -   5          Name$ 	dataGrid1��5/   �      CanUserReorderColumns .  |�.     CanUserAddRows .  $��1��6|      AutoGenerateColumns .     FrozenColumnCount$ 1��6�   ���	#FFDAD5D5��6   ��    Columns 50      4  .System.Windows.Controls.DataGridTemplateColumn  51      ,  &System.Windows.Controls.DataGridColumn   Header$ 操作��6-   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 69   
   CellTemplate
 52      �� 53      .R�54   "   ��  �� Orientation$ 
Horizontal=�55   %   $��Center=�6>   $��Center=�6[   .+�56   &   ��  ��Name$ addBtn��57   )   -   5         *  &MaterialDesignFloatingActionMiniButton#���   5:   )   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�5;   )   $��新增��6Z   
 � Tag 58   )   ��  �� Path$ LoginID�5;   Z   �� 5=   &   $ 	deleteBtn��5@   )   -   5        $��5 0 5 0q�5>   )   #���   5A   )   $ Depth5=�5B   )   $��删除��6Z    5?   )   �� $ LoginID�5B   g   �� 5C   &   $ Modifly_btn��5D   )   -   5        #���   5F   )   $ Depth5=�5G   )   $��修改��6Z    5E   )   �� $ LoginID�5G   g   5H   #   5I      5K      0  *System.Windows.Controls.DataGridTextColumn  5L      $ 账号��6)   $
	 0.5* 65      
FontWeight$
 Bold"�6E      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6W   �� *	Account+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�     5M      $ 姓名��6)   $
	 0.5* 65   $
 Bold"�6B    .  6T   �� *
UserName+$ TwoWay=�$ PropertyChanged=�6�     5N      $ 年龄��6)   $
	 0.5* 65   $
 Bold"�6B    .  6T   �� *Age+$ TwoWay=�$ PropertyChanged=�6�     5O      $ 性别��6)   $
	 0.5* 65   $
 Bold"�6B    .  6T   �� *Sex+$ TwoWay=�$ PropertyChanged=�6�     5d      $ 职务��6)   $
 Bold"�69    . $
	 0.5* 6�    6_   �� *Job+$ TwoWay=�$ PropertyChanged=�6�     5e      $ 工号��6)   $
 Bold"�69    . $
	 0.5* 6�    6_   �� *EmpNo+$ TwoWay=�$ PropertyChanged=�6�     5f      $ 创建时间��6)   $
 Bold"�67    . $	 * 6�    6]   �� *
CreateTime+$ TwoWay=�$ PropertyChanged=�6�     5g      $ 修改时间��6)   $
 Bold"�67    . $	 * 6�    6]   �� *
ModifyTime+$ TwoWay=�$ PropertyChanged=�6�     5h      $ 地址��6)   $
 Bold"�69    . $	 * 6�    6_   �� *	Address+$ TwoWay=�$ PropertyChanged=�6�     5i      $ 状态��6)   $
 Bold"�69    . $
	 0.5* 6�    6_   �� *Status+$ TwoWay=�$ PropertyChanged=�6�   5k      �� 5m      $��0 0 0 10q�6   $��2��6,   $ 
Horizontal=�69   $��Bottom=�6S   .+�5n      �� $��转到��6   $��8q�6&   $��Center=�61   �� 5o      -   5         ��Name$ 
tbxPageNum��5o      $�� ��6.   $��Center=�66   $��30��6Q    �� TextAlignment$ Center=�6\   �� 5p      $	��页��6   $��Center=�6%   $��8q�6@   �� 5q      -   5        $ Btn_Go��5q      $��GO��6)   $��Center=�66   ���	#FF636265$��8q�6o   
������ 6�   �� 5r      -   5        $ btnUp��5r      $��8q�6)   $��	上一页��64   $��Center=�6C   ���	#FF6D6D6E
������ 6�   �� 5s      -	   5        $ btnNext��5s      $��8q�6*   $��	下一页��65   $��Center=�6D   ���	#FF7B7A7D
������ 6�   �� 5t      $��20��6   �� 5u      $��【共��6    �� 5v      -
   5        $��tbkTotal��5v       �� 5w      $��条】��6    �� 5x      $��	【当前��6    �� 5y      -   5        $��tbkCurrentsize��5y       �� 5z      $��页】��6   5{   
   5}      5�      5�      5�      