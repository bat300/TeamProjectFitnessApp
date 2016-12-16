using FitnessDietApp.Data;
using FitnessDietApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для PageOfAnalysis.xaml
    /// </summary>
    public partial class PageOfAnalysis : Page
    {
        public PageOfAnalysis()
        {
            InitializeComponent();
            IAnalysing analyse = Factory.Default.GetIAnalysing();

            analyse.RecomendationMessage += (a =>listBoxForRecommendations.Items.Add(a));
            double Max = 0;
            double Width = 0;
            using (Context context = new Context())
            {
                InfoProDaySummarising inf = new InfoProDaySummarising();
                foreach (var item in context.Diary)
                {
                    double CarbohydratesProDay = inf.CarbohydratesPerDay(item.DiaryItems);
                   
                    double FatsProDay = inf.FatsPerDay(item.DiaryItems);
                    
                    double ProteinsProDay = inf.ProteinsPerDay(item.DiaryItems);
                    
                    double CalloriesProDay = inf.CalloriesPerDay(item.DiaryItems);
                    
                    if (CarbohydratesProDay > Max)
                    {
                        Max = CarbohydratesProDay;
                    }
                    if (FatsProDay > Max)
                    {
                        Max = FatsProDay;
                    }
                    if (ProteinsProDay > Max)
                    {
                        Max = ProteinsProDay;
                    }
                    if (CalloriesProDay > Max)
                    {
                        Max = CalloriesProDay;
                    }
                    Width += 1;
                }
                double Width2 = (Width - 1) / Width;
                double Hight = Math.Round(Max) + 1;
                DrawingGroup CallsDrawingGroup = new DrawingGroup();
                IDeviationsCalculating dev = Factory.Default.GetDeviationsCalculating();
                for (int Stages = 0; Stages < 10; Stages++)
                {
                    GeometryDrawing GeoDrawing = new GeometryDrawing();
                    GeometryGroup GeoGroup = new GeometryGroup();
                    //Задний фон
                    if (Stages == 0)
                    {
                        GeoDrawing.Brush = Brushes.Beige;
                        GeoDrawing.Pen = new Pen(Brushes.Black, 3);

                        RectangleGeometry Background = new RectangleGeometry();
                        //Background.Rect = new Rect(0, 0, (Math.Round(Max) + 1) * Width2, Math.Round(Max) + 1);
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
                        foreach (var item in context.Diary)
                        {
                            double ProteinsProDay = inf.ProteinsPerDay(item.DiaryItems);
                            if (i != 0)
                            {
                                LineGeometry lGeo = new LineGeometry(new Point((Math.Round(Max) + 1) * (i - 1) / Width,
                                    Hight - last), new Point((Math.Round(Max) + 1) * i / Width, Hight - ProteinsProDay));
                                GeoGroup.Children.Add(lGeo);
                            }
                            last = ProteinsProDay;
                            i += 1;
                        }
                    }
                    //График жиров
                    if (Stages == 2)
                    {
                        GeoDrawing.Brush = Brushes.DeepPink;
                        GeoDrawing.Pen = new Pen(Brushes.DeepPink, 2);

                        int i = 0;
                        double last = 0;
                        GeoGroup = new GeometryGroup();
                        foreach (var item in context.Diary)
                        {
                            double FatsProDay = inf.FatsPerDay(item.DiaryItems);
                            if (i != 0)
                            {
                                LineGeometry lGeo = new LineGeometry(new Point((Math.Round(Max) + 1) * (i - 1) / Width,
                                    Hight - last), new Point((Math.Round(Max) + 1) * i / Width, Hight - FatsProDay));
                                GeoGroup.Children.Add(lGeo);
                            }
                            last = FatsProDay;
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
                        foreach (var item in context.Diary)
                        {
                            double CarbohydratesProDay = inf.CarbohydratesPerDay(item.DiaryItems);
                            if (i != 0)
                            {
                                LineGeometry lGeo = new LineGeometry(new Point((Math.Round(Max) + 1) * (i - 1) / Width,
                                    Hight - last), new Point((Math.Round(Max) + 1) * i / Width, Hight - CarbohydratesProDay));
                                GeoGroup.Children.Add(lGeo);
                            }
                            last = CarbohydratesProDay;
                            i += 1;
                        }
                    }
                    //Все красные точки
                    if (Stages == 4)
                    {
                        GeoGroup = new GeometryGroup();
                        int i = 0;
                        foreach (var item in context.Diary)
                        {
                            double CarbohydratesProDay = inf.CarbohydratesPerDay(item.DiaryItems);
                            double DeviationOfCarbohydratesProDay = dev.DeviationOfCarbohydratesPerDay(CarbohydratesProDay,
                                item.PersonNorm);
                            double FatsProDay = inf.FatsPerDay(item.DiaryItems);
                            double DeviationOfFatsProDay = dev.DeviationOfFatsPerDay(FatsProDay, item.PersonNorm);
                            double ProteinsProDay = inf.ProteinsPerDay(item.DiaryItems);
                            double DeviationOfProteinsProDay = dev.DeviationOfProteinsPerDay(ProteinsProDay, item.PersonNorm);
                            double CalloriesProDay = inf.CalloriesPerDay(item.DiaryItems);
                            double DeviationOfCalloriesProDay = dev.DeviationOfCalloriesPerDay(CalloriesProDay,
                                item.PersonNorm);
                            GeoDrawing.Brush = Brushes.Red;
                            GeoDrawing.Pen = new Pen(Brushes.Red, 8);
                            if (DeviationOfProteinsProDay > 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width,
                                    Hight - ProteinsProDay), 1, 1);

                                GeoGroup.Children.Add(Dot);
                            }
                           
                                if (DeviationOfCarbohydratesProDay > 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width,
                                    Hight - CarbohydratesProDay), 1, 1);

                                GeoGroup.Children.Add(Dot);
                            }
                            
                                if (DeviationOfFatsProDay > 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width,
                                    Hight - FatsProDay), 1, 1);
                                GeoGroup.Children.Add(Dot);
                            }
                            if (DeviationOfCalloriesProDay > 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width,
                                    Hight - CalloriesProDay), 1, 1);
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
                        foreach (var item in context.Diary)
                        {
                            double CarbohydratesProDay = inf.CarbohydratesPerDay(item.DiaryItems);
                            double DeviationOfCarbohydratesProDay = dev.DeviationOfCarbohydratesPerDay(CarbohydratesProDay,
                                item.PersonNorm);
                            double FatsProDay = inf.FatsPerDay(item.DiaryItems);
                            double DeviationOfFatsProDay = dev.DeviationOfFatsPerDay(FatsProDay, item.PersonNorm);
                            double ProteinsProDay = inf.ProteinsPerDay(item.DiaryItems);
                            double DeviationOfProteinsProDay = dev.DeviationOfProteinsPerDay(ProteinsProDay, item.PersonNorm);
                            double CalloriesProDay = inf.CalloriesPerDay(item.DiaryItems);
                            double DeviationOfCalloriesProDay = dev.DeviationOfCalloriesPerDay(CalloriesProDay,
                                item.PersonNorm);
                            GeoDrawing.Brush = Brushes.Orange;
                            GeoDrawing.Pen = new Pen(Brushes.Orange, 8);
                            if (DeviationOfProteinsProDay < 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width,
                                    Hight - ProteinsProDay), 1, 1);

                                GeoGroup.Children.Add(Dot);
                            }
                            
                                if (DeviationOfCarbohydratesProDay < 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width,
                                    Hight - CarbohydratesProDay), 1, 1);

                                GeoGroup.Children.Add(Dot);
                            }
                            
                                if (DeviationOfFatsProDay < 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width,
                                    Hight - FatsProDay), 1, 1);
                                GeoGroup.Children.Add(Dot);
                            }
                            if (DeviationOfCalloriesProDay < 0)
                            {
                                EllipseGeometry Dot = new EllipseGeometry(new Point((Math.Round(Max) + 1) * i / Width,
                                    Hight - CalloriesProDay), 1, 1);
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
                    //Сетка
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
                    //Каллории
                    if (Stages == 8)
                    {
                        GeoDrawing.Brush = Brushes.Black;
                        GeoDrawing.Pen = new Pen(Brushes.Black, 2);

                        int i = 0;
                        double last = 0;
                        GeoGroup = new GeometryGroup();
                        foreach (var item in context.Diary)
                        {
                            double CalloriesProDay = inf.CalloriesPerDay(item.DiaryItems);
 
                            if (i != 0)
                            {
                                LineGeometry lGeo = new LineGeometry(new Point((Math.Round(Max) + 1) * (i - 1) / Width,
                                    Hight - last), new Point((Math.Round(Max) + 1) * i / Width, Hight - CalloriesProDay));
                                GeoGroup.Children.Add(lGeo);
                            }
                            last = CalloriesProDay;
                            i += 1;
                        }
                    }
                    //Надписи снизу
                    if (Stages == 9)
                    {
                        GeoDrawing.Brush = Brushes.Black;
                        GeoDrawing.Pen = new Pen(Brushes.Black, 2);
                        int i = 0;
                        foreach (var item in context.Diary)
                        {
                            FormattedText formText = new FormattedText(
                                item.Date.ToString(),
                                CultureInfo.GetCultureInfo("en-us"),
                                FlowDirection.LeftToRight,
                                new Typeface("Arial"),
                                16,
                                Brushes.Black);
                            Geometry Geo = formText.BuildGeometry(new Point((Math.Round(Max) + 1) * i / Width, Max + 5));
                            GeoGroup.Children.Add(Geo);
                            i += 1;
                        }
                    }
                    GeoDrawing.Geometry = GeoGroup;
                    CallsDrawingGroup.Children.Add(GeoDrawing);
                }

                image.Source = new DrawingImage(CallsDrawingGroup);
            }
        }
    }
}
