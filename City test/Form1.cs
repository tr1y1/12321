using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;

namespace City_test
{
    public partial class City_test : Form
    {
        private const int ROAD_SIZE = 34;

        // Сбрасываются координаты выделенной зоны
        private int[] _selectedRoadPosition = new int[] { -1, -1 };

        // Задается позиция машины
        private int[] _carPosition = new int[] { 17, 19, 0 };

        // ИИ
        private int[] _lastCross = new int[2];
        private int _iteration = 0;
        private int _step = 0;
        private int _bestResult = 0;


        // Определение базы данных SQLite
        private SQLiteConnection _connection = new SQLiteConnection("Data Source=database.db");
        private SQLiteCommand _command = new SQLiteCommand();

        // Ссылки на изображения используемых дорог
        private Bitmap[] _roadBitmaps = new Bitmap[]
        {
            null,
            Properties.Resources.Road,
            Properties.Resources.Road,
            Properties.Resources.Road,
            Properties.Resources.Road,
            Properties.Resources.Road_cross,
            Properties.Resources.Start,
            Properties.Resources.Finish
        };

        // Ссылки на изображения вариантов машины
        private Bitmap[] _carBitmaps = new Bitmap[]
        {
            Properties.Resources.Car_Top,
            Properties.Resources.Car_Right,
            Properties.Resources.Car_bottom,
            Properties.Resources.Car_Left
        };

        // Массив по которому строится дорога
        private int[,] _roadmap = {
            {0,2,1,0,0,0,2,1,0,0,0,0,2,1,0,0,0,0,0,0 },
            {0,2,1,0,0,0,2,1,0,0,0,0,2,1,0,0,0,0,0,0 },
            {0,5,5,4,4,4,5,5,4,4,4,4,5,5,4,4,5,5,4,4 },
            {0,5,5,3,3,3,5,5,3,3,3,3,5,5,3,3,5,5,3,3 },
            {0,2,1,0,0,0,2,1,0,0,0,0,2,1,0,0,2,1,0,0 },
            {7,5,5,0,0,0,2,1,0,0,0,0,2,1,0,0,2,1,0,0 },
            {3,5,5,0,0,0,5,5,4,4,4,4,5,5,0,0,2,1,0,0 },
            {0,2,1,0,0,0,5,5,3,3,3,3,5,5,0,0,2,1,0,0 },
            {0,2,1,0,0,0,2,1,0,0,0,0,5,5,4,4,5,5,4,4 },
            {0,5,5,4,4,4,5,5,0,0,0,0,5,5,3,3,5,5,3,3 },
            {0,5,5,3,3,3,5,5,0,0,0,0,2,1,0,0,2,1,0,0 },
            {0,2,1,0,0,0,5,5,4,4,4,4,5,5,0,0,2,1,0,0 },
            {0,2,1,0,0,0,5,5,3,3,3,3,5,5,0,0,2,1,0,0 },
            {0,2,1,0,0,0,2,1,0,0,0,0,2,1,0,0,2,1,0,0 },
            {0,2,1,0,0,0,2,1,0,0,0,0,2,1,0,0,2,1,0,0 },
            {0,2,1,0,0,0,2,1,0,0,0,0,2,1,0,0,2,1,0,0 },
            {4,5,5,4,4,4,5,5,4,4,4,4,5,5,4,4,5,5,0,0 },
            {3,5,5,3,3,3,5,5,3,3,3,3,5,5,3,3,5,5,0,0 },
            {0,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1,0,0 },
            {0,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,2,6,0,0 },
        };

        // Массив по которому расставляются знаки и машина
        private int[,] _objects = {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0 },
            {0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0 },
            {0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0 },
        };

        public City_test()
        {
            InitializeComponent();

            // Соединение с базой данных
            _connection.Open();
            _command.Connection = _connection;
            // Создание таблицы в базе данных, если ее нет
            _command.CommandText = "CREATE TABLE IF NOT EXISTS Logs (Log_Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Log_result STRING NOT NULL, Log_time STRING NOT NULL)";
            _command.ExecuteNonQuery();
        }

        private void TransposeArrays()
        {
            // Цикл, переворачивающий массивы дорог и объектов
            int[,] roadmap = new int[20, 20];
            int[,] objects = new int[20, 20];
                for (int x = 0; x < 20; x++)
                {
                    for (int y = 0; y < 20; y++)
                    {
                        roadmap[x, y] = _roadmap[y, x];
                        objects[x, y] = _objects[y, x];
                    }
                }
            _roadmap = roadmap;
            _objects = objects;
            
        }
        private void BuildRoad()
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    // Создание изображения дороги
                    PictureBox road = new PictureBox
                    {
                        Name = $"{x}_{y}",
                        Size = new Size(ROAD_SIZE, ROAD_SIZE),
                        Location = new Point(ROAD_SIZE * x, ROAD_SIZE * y),
                    };

                    // Привязка событий
                    road.Click += RoadClick; // Выделение при нажатии на участок дороги
                    road.MouseHover += RoadHover; // Отображение координатов блока при наведении на участок дороги

                    // Заполение панели на форме изображениями
                    panel.Controls.Add(road);
                }
            }
        }
        private void DrawRoad() 
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {
                    // Доступ к картинке дороги
                    PictureBox road = panel.Controls[x + "_" + y] as PictureBox;
                    road.BackgroundImage = _roadBitmaps[_roadmap[x, y]];

                    // Поворот картинки
                    switch (_roadmap[x, y])
                    {
                        case 2:
                            road.BackgroundImage = RotateImage(road.BackgroundImage, 180);
                            //road.BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            break;
                        case 3:
                            road.BackgroundImage = RotateImage(road.BackgroundImage, 90);
                            break;
                        case 4:
                            road.BackgroundImage = RotateImage(road.BackgroundImage, 270);
                            break;
                    }

                    // Установка кирпичей и машины
                    switch (_objects[x, y])
                    {
                        case 1:
                            road.Image = Properties.Resources.Block;
                            break;
                        case 2:
                            road.Image = Properties.Resources.Car_Top;
                            break;
                    }
                }
            }
        }

        private Image RotateImage(Image image, float angle)
        {
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                g.TranslateTransform(image.Width / 2, image.Height / 2);
                g.RotateTransform(angle);
                g.DrawImage(image, -image.Width / 2, -image.Height / 2, image.Width, image.Height);
            }
            return rotatedImage;
        }

        private void CityTest_Load(object sender, EventArgs e)
        {
            TransposeArrays(); // Необходимо перевернуть массивы
            BuildRoad(); // Построение карты
            DrawRoad(); // Отрисовка объектов и дороги
        }

        private void RoadClick(object sender, EventArgs e)
        {
            PictureBox road = sender as PictureBox;
            string[] roadPosition = road.Name.Split('_');
            int x = int.Parse(roadPosition[0]);
            int y = int.Parse(roadPosition[1]);

            // Удаление рамок на предыдущей выделенной дороге
            if (_selectedRoadPosition[0] > 0)
            {
                PictureBox selectedRoad = panel.Controls[_selectedRoadPosition[0] + "_" + _selectedRoadPosition[1]] as PictureBox;
                selectedRoad.BorderStyle = BorderStyle.None;
            }

            // Выделение дороги
            road.BorderStyle = BorderStyle.Fixed3D;
            button_add.Enabled = true;
            _selectedRoadPosition[0] = x;
            _selectedRoadPosition[1] = y;
            if (_objects[_selectedRoadPosition[0], _selectedRoadPosition[1]] == 1)
            {
                button_delete.Enabled = true;
            }
            else
            {
                button_delete.Enabled = false;
            }
        }

        private void RoadHover(object sender, EventArgs e)
        {
            // Отображение координатов при наведении курсора на участок дороги
            PictureBox road = sender as PictureBox;
            label_info.Text = "Координаты выбранной зоны: " + road.Name;
        }

        private void MoveCar()
        {
            // Запись координаты машины в переменные
            int x = _carPosition[0];
            int y = _carPosition[1];
            int direction = _carPosition[2];

            // Получение текущей дороги
            PictureBox roadStart = panel.Controls[x + "_" + y] as PictureBox;

            // Определение возможности двигаться дальше
            ChangePosition(direction, ref x, ref y);

            // Проверка на доступность движения по дороге прямо
            if (x < 20 && y < 20 && x >= 0 && y >= 0)
            {
                // Проверка на наличие знаков на дороге
                if (_roadmap[x, y] != 0 && _objects[x, y] == 0 && _roadmap[x, y] != 6)
                {
                    // Получение следующей дороги
                    PictureBox roadEnd = panel.Controls[x + "_" + y] as PictureBox;

                    // Обновляем положение изображения
                    roadStart.Image = null;
                    roadEnd.Image = _carBitmaps[direction];

                    // Сохраняем координаты последнего выезда с дороги
                    if (_roadmap[_carPosition[0], _carPosition[1]] == 5)
                    {
                        if (_roadmap[x, y] != 5)
                        {
                            _lastCross[0] = x;
                            _lastCross[1] = y;
                        }
                    }

                    // Обновление координатов машины
                    _carPosition = new int[] { x, y, direction };

                    // Проверка на наличие финиша по координатам машины и последующее завершение итерации финишем
                    if (_roadmap[x, y] == 7)
                    {
                        if (_bestResult == 0 || _step < _bestResult)
                        {
                            _bestResult = _step;
                            label_best.Text = "Лучший результат: " + _bestResult.ToString();
                        }
                        StopMove(true);
                    }
                }
                else
                {
                    // Алгоритм движения если машина находится на перекрестке
                    if (_roadmap[_carPosition[0], _carPosition[1]] == 5)
                    {
                        // Пробуем повернуть направо
                        x = _carPosition[0];
                        y = _carPosition[1];
                        direction = RotateRight(direction, 1);
                        ChangePosition(direction, ref x, ref y);

                        if (CompareRotation(direction, _roadmap[x, y]))
                        {
                            _carPosition[2] = direction;
                            roadStart.Image = _carBitmaps[direction];
                        }
                        else
                        {
                            // Пробуем повернуть налево
                            direction = RotateRight(direction, 2);
                            x = _carPosition[0];
                            y = _carPosition[1];
                            ChangePosition(direction, ref x, ref y);
                            ChangePosition(direction, ref x, ref y);

                            if (CompareRotation(direction, _roadmap[x, y]))
                            {
                                _carPosition[2] = direction;
                                roadStart.Image = _carBitmaps[direction];
                            }
                            else
                            {
                                x = _carPosition[0];
                                y = _carPosition[1];

                                StopMove(false);
                                SetBlock(x, y);
                            }
                        }
                    }
                    else
                    {
                        StopMove(false);
                        SetBlockOnCross();
                    }
                }
            }
            else
            {
                StopMove(false);
                SetBlockOnCross();
            }
        }

        private void StopMove(bool result)
        {
            // Удаление машины
            PictureBox car = panel.Controls[_carPosition[0] + "_" + _carPosition[1]] as PictureBox;
            car.Image = null;
            string resultStr;
            // Установка машины на начальные координаты
            _carPosition = new int[3] { 17, 19, 0 };

            // Установка машины на старт
            car = panel.Controls[_carPosition[0] + "_" + _carPosition[1]] as PictureBox;
            car.Image = Properties.Resources.Car_Top;

            if (result == false)
            {
                resultStr = "Провал";
            }
            else
            {
                resultStr = "Финиш";
            }

            // Запись результата поездки в БД
            _command.CommandText = "INSERT INTO Logs (Log_result, Log_time) VALUES ('" + resultStr + "', " + _step + ")";
            _command.ExecuteNonQuery();

            _iteration++;
            label_iteration.Text = "Итерация: " + _iteration.ToString();
            _step = 0;
        }

        private bool CompareRotation(int directionCar, int directionRoad)
        {
            // Алгоритм, отвечающий за выезд с перекрестка
            switch (directionCar)
            {
                case 0:
                    return (directionRoad == 1 || directionRoad == 5);
                case 1:
                    return (directionRoad == 3 || directionRoad == 5);
                case 2:
                    return (directionRoad == 2 || directionRoad == 5 || directionRoad == 7);
                case 3:
                    return (directionRoad == 4 || directionRoad == 5 || directionRoad == 7);
            }
            return false;
        }

        private void ChangePosition(int direction, ref int x, ref int y)
        {
            // Алгоритм отвечающий за движение машины
            // 0 - Вверх
            // 1 - Вправо
            // 2 - Вниз
            // 3 - Влево
            switch (direction)
            {
                case 0:
                    y--;
                    break;
                case 1:
                    x++;
                    break;
                case 2:
                    y++;
                    break;
                case 3:
                    x--;
                    break;
            }
        }

        private int RotateRight(int direction, int count)
        {
            // Функция отвечающая за поворот машины
            direction += count;
            while (direction >= 4)
            {
                direction -= 4;
            }

            while (direction < 0)
            {
                direction += 4;
            }

            return direction;
        }

        private void SetBlockOnCross()
        {
            // Установка знака на дороге, где дальше не имеется проезда к финишу
            _roadmap[_lastCross[0], _lastCross[1]] = 6;
            PictureBox road = panel.Controls[_lastCross[0] + "_" + _lastCross[1]] as PictureBox;
            road.Image = Properties.Resources.Block_AI;
        }

        private void SetBlock(int x, int y)
        {
            // Установка знака на дороге, где дальше не имеется проезда к финишу
            _roadmap[x, y] = 6;
            PictureBox road = panel.Controls[x + "_" + y] as PictureBox;
            road.Image = Properties.Resources.Block_AI;
        }

        private void button_up_Click(object sender, EventArgs e)
        {
            // Движение машины вперед при нажатии на кнопку Forward
            ++_step;
            MoveCar();
            label_step.Text = "Шагов за итерацию: " + _step;
        }

        private void button_left_Click(object sender, EventArgs e)
        {
            // Поворот машины налево
            RotateCar(-1);
            ++_step;
            MoveCar();
            label_step.Text = "Шагов за итерацию: " + _step;
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            // Разворот машины
            MoveCar();
            RotateCar(-1);
            MoveCar();
            RotateCar(-1);
        }

        private void button_right_Click(object sender, EventArgs e)
        {
            // Поворот машины направо
            RotateCar(1);
            ++_step;
            MoveCar();
            label_step.Text = "Шагов за итерацию: " + _step;
        }

        private void RotateCar(int rotate)
        {
            // Функция отвечающая за поворот машины
            int x = _carPosition[0];
            int y = _carPosition[1];
            int direction = _carPosition[2];

            direction = RotateRight(direction, rotate);
            _carPosition[2] = direction;

            PictureBox road = panel.Controls[x + "_" + y] as PictureBox;
            road.Image = _carBitmaps[direction];
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            timer.Interval = (10 - trackBar.Value) * 100;
            label_speed.Text = "Частота обновления: " + timer.Interval + " мс";
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            timer.Start();
            button_end.Enabled = true;
            button_start.Enabled = false;
        }

        private void button_end_Click(object sender, EventArgs e)
        {
            timer.Stop();
            StopMove(false);
            button_end.Enabled = false;
            button_start.Enabled = true;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            int x = _selectedRoadPosition[0];
            int y = _selectedRoadPosition[1];

            if (x != -1)
            {
                if (_roadmap[x, y] >= 1 & _roadmap[x, y] <= 4)
                {
                    PictureBox selectedRoad = panel.Controls[x + "_" + y] as PictureBox;
                    selectedRoad.Image = Properties.Resources.Block;
                    _objects[x, y] = 1;
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int x = _selectedRoadPosition[0];
            int y = _selectedRoadPosition[1];

            if (x != -1)
            {
                PictureBox road = panel.Controls[x + "_" + y] as PictureBox;
                road.Image = null;
                _objects[x, y] = 0;
                button_delete.Enabled = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MoveCar();
            _step++;
            label_step.Text = "Шагов за итерацию: " + _step.ToString();
        }
    }
}
