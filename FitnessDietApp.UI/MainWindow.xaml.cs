using FitnessDietApp.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FitnessDietApp.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Context context = Factory.Default.GetContext();

            double Max = 0;
            double Width = 0;
            using (context)
            {
                foreach (var item in context.InfoProDaySummarisings)
                {
                    if (item.CarbohydratesProDay > Max)
                    {
                        Max = item.CarbohydratesProDay;
                    }
                    if (item.FatsProDay > Max)
                    {
                        Max = item.FatsProDay;
                    }
                    if (item.ProteinsProDay > Max)
                    {
                        Max = item.ProteinsProDay;
                    }
                    if (item.CalloriesProDay > Max)
                    {
                        Max = item.CalloriesProDay;
                    }
                    Width += 1;
                }
                double Width2 = (Width - 1) / Width;
                double Hight = Math.Round(Max) + 1;
                DrawingGroup CallsDrawingGroup = new DrawingGroup();
                for (int Stages = 0; Stages < 7; Stages++)
                {
                    GeometryDrawing GeoDrawing = new GeometryDrawing();
                    GeometryGroup GeoGroup = new GeometryGroup();
                    //Задний фон
                    if (Stages == 0)
                    {
                        GeoDrawing.Brush = Brushes.Beige;
                        GeoDrawing.Pen = new Pen(Brushes.Black, 3);

                        RectangleGeometry Background = new RectangleGeometry();
                        Background.Rect = new Rect(0, 0, (Math.Round(Max) + 1) * Width2, Math.Round(Max) + 1);
                        GeoGroup.Children.Add(Background);
                    }
                    //График протеинов

                    if (Stages == 1)
                    {
                        GeoDrawing.Brush = Brushes.White;
                        GeoDrawing.Pen = new Pen(Brushes.Green, 2);

                        int i = 0;
                        double last = 0;
                        GeoGroup = new GeometryGroup();
                        foreach (var item in context.InfoProDaySummarisings)
                        {
                            if (i != 0)
                            {
                                LineGeometry lGeo = new LineGeometry(new Point((Math.Round(Max) + 1) * (i - 1) / Width, Hight - last), new Point((Math.Round(Max) + 1) * i / Width, Hight - item.ProteinsProDay));
                                GeoGroup.Children.Add(lGeo);
                            }
                            last = item.ProteinsProDay;
                            i += 1;
                        }
                    }
                    //График жиров
                    if (Stages == 2)
                    {
                        GeoDrawing.Brush = Brushes.White;
                        GeoDrawing.Pen = new Pen(Brushes.Pink, 2);

                        int i = 0;
                        double last = 0;
                        GeoGroup = new GeometryGroup();
                        foreach (var item in context.InfoProDaySummarisings)
                        {
                            if (i != 0)
                            {
                                LineGeometry lGeo = new LineGeometry(new Point((Math.Round(Max) + 1) * (i - 1) / Width, Hight - last), new Point((Math.Round(Max) + 1) * i / Width, Hight - item.FatsProDay));
                                GeoGroup.Children.Add(lGeo);
                            }
                            last = item.FatsProDay;
                            i += 1;
                        }
                    }
                    //График углеводов
                    if (Stages == 3)
                    {
                        GeoDrawing.Brush = Brushes.White;
                        GeoDrawing.Pen = new Pen(Brushes.Blue, 2);

                        int i = 0;
                        double last = 0;
                        GeoGroup = new GeometryGroup();
                        foreach (var item in context.InfoProDaySummarisings)
                        {
                            if (i != 0)
                            {
                                LineGeometry lGeo = new LineGeometry(new Point((Math.Round(Max) + 1) * (i - 1) / Width, Hight - last), new Point((Math.Round(Max) + 1) * i / Width, Hight - item.CarbohydratesProDay));
                                GeoGroup.Children.Add(lGeo);
                            }
                            last = item.CarbohydratesProDay;
                            i += 1;
                        }
                    }
                    //Все красные точки
                    if (Stages == 4)
                    {
                        GeoGroup = new GeometryGroup();
                        int i = 0;
                        foreach (var item in context.InfoProDaySummarisings)
                        {
                            GeoDrawing.Brush = Brushes.Red;
                            GeoDrawing.Pen = new Pen(Brushes.Red, 5);
                            if (item.DeviationOfProteinsProDay > 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width, Hight - item.ProteinsProDay), 1, 1);

                                GeoGroup.Children.Add(Dot);
                            }
                            else
                                if (item.DeviationOfCarbohydratesProDay > 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width, Hight - item.CarbohydratesProDay), 1, 1);

                                GeoGroup.Children.Add(Dot);
                            }
                            else
                                if (item.DeviationOfFatsProDay > 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width, Hight - item.FatsProDay), 1, 1);
                                GeoGroup.Children.Add(Dot);
                            }
                            i += 1;
                        }
                    }
                    //Все жёлтые точки
                    if (Stages == 5)
                    {
                        GeoGroup = new GeometryGroup();
                        int i = 0;
                        foreach (var item in context.InfoProDaySummarisings)
                        {
                            GeoDrawing.Brush = Brushes.Yellow;
                            GeoDrawing.Pen = new Pen(Brushes.Orange, 5);
                            if (item.DeviationOfProteinsProDay < 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width, Hight - item.ProteinsProDay), 1, 1);

                                GeoGroup.Children.Add(Dot);
                            }
                            else
                                if (item.DeviationOfCarbohydratesProDay < 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width, Hight - item.CarbohydratesProDay), 1, 1);

                                GeoGroup.Children.Add(Dot);
                            }
                            else
                                if (item.DeviationOfFatsProDay < 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width, Hight - item.FatsProDay), 1, 1);
                                GeoGroup.Children.Add(Dot);
                            }
                            i += 1;
                        }
                    }
                    //Надписи
                    if (Stages == 6)
                    {
                        GeoDrawing.Brush = Brushes.Black;
                        GeoDrawing.Pen = new Pen(Brushes.Black, 2);
                        for (int i = 0; i < Max + 2; i += 50)
                        {
                            FormattedText formText = new FormattedText(
                                i.ToString(),
                                CultureInfo.GetCultureInfo("en-us"),
                                FlowDirection.LeftToRight,
                                new Typeface("Arial"),
                                16,
                                Brushes.Black);
                            //formText.SetFontWeight(FontWeights.Light);
                            Geometry Geo = formText.BuildGeometry(new Point(-40, Hight - i));
                            GeoGroup.Children.Add(Geo);
                        }
                    }
                    //Сетка?????????????????????????????????????????????????????????????????????????????
                    if (Stages == 7)
                    {
                        GeoDrawing.Brush = Brushes.Beige;
                        GeoDrawing.Pen = new Pen(Brushes.Gray, 1);
                        //DoubleCollection dashes = new DoubleCollection();
                        List<double> dashes = new List<double>();
                        for (int i = 0; i < Math.Round(Max) + 1; i += 50)
                        {
                            dashes.Add(0.8);
                        }
                        GeoDrawing.Pen.DashStyle = new DashStyle(dashes, 0);


                        for (int i = 0; i < Math.Round(Max) + 1; i += 50)
                        {
                            LineGeometry LGeo = new LineGeometry(new Point(0, i), new Point((Math.Round(Max) + 1) * Width2, i));
                            GeoGroup.Children.Add(LGeo);
                        }
                    }
                    //??????????????????????????????????????????????????????????????????????????????????
                    GeoDrawing.Geometry = GeoGroup;
                    CallsDrawingGroup.Children.Add(GeoDrawing);
                }

                image.Source = new DrawingImage(CallsDrawingGroup);
            }
        }
    }
}


