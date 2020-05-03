using GlmNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSA_Calculator
{
    class HGT
    {
        public const int DEFAULT_RESOLUTION = 1201;

        public short[,][] map = new short[360, 180][];

        public vec2 peakCoordinate = new vec2();

        // Debug
        public List<String> loadedFiles = new List<String>();
        public vec4 routeBoundingBox = new vec4();

        // Objective:   Calculates the angle between two points. 0 radians is at 3 oclock and increases counter-clockwise
        // Input:       (short) p1:          origin point to measure
        //              (short) p2:          destination point to measure the angle
        // Output:      (double) result:     angle in radians from p1 to p2
        public static double angleBetweenTwoPoints(vec2 p1, vec2 p2)
        {
            vec2 center = p1;
            double start = Math.Atan2(p1.y - center.y, p1.x - center.x);
            double end = Math.Atan2(p2.y - center.y, p2.x - center.x);
            double result = end - start;
            return result;
        }

        // Objective:   Calculates the four vertices of a rectangle which contains a line set by two points
        // Input:       (vec2) p1:         point of the line
        //              (vec2) p2:         point of the line
        //              (double) distance: distance from the line to the side of the rectangle
        // Output:      (vec2[]) result:   vertices of the rectangle
        public static vec2[] getRouteRectangle(vec2 p1, vec2 p2, double distance)
        {
            List<vec2> result = new List<vec2>();

            var angle = angleBetweenTwoPoints(p1, p2);

            result.Add(new vec2((float)(p1.x + Math.Cos(angle - 3 * Math.PI / 4) * distance), (float)(p1.y + Math.Sin(angle - 3 * Math.PI / 4) * distance)));
            result.Add(new vec2((float)(p1.x + Math.Cos(angle + 3 * Math.PI / 4) * distance), (float)(p1.y + Math.Sin(angle + 3 * Math.PI / 4) * distance)));
            result.Add(new vec2((float)(p2.x + Math.Cos(angle + 1 * Math.PI / 4) * distance), (float)(p2.y + Math.Sin(angle + 1 * Math.PI / 4) * distance)));
            result.Add(new vec2((float)(p2.x + Math.Cos(angle - 1 * Math.PI / 4) * distance), (float)(p2.y + Math.Sin(angle - 1 * Math.PI / 4) * distance)));

            return result.ToArray();
        }

        // Objective:   Load the elevation files based on the search rectangle
        // Input:       (vec2[]) rectangle: search rectangle
        // Output:      (null)
        public void loadFiles(vec2[] rectangle)
        {
            // Get the bounding box of the rectangle
            routeBoundingBox = getBoundingBox(rectangle);

            for (short i = (short)routeBoundingBox.w; i <= (short)routeBoundingBox.x; i++)
            {
                for (short j = (short)routeBoundingBox.y; j <= (short)routeBoundingBox.z; j++)
                {
                    loadFile(i, j);
                }
            }
        }

        // Objective:   Get the bounding box of the rectangle
        // Input:       (vec2[]) v:        vertices of the rectangle
        // Output:      (vec4) result:     bounding box
        public static vec4 getBoundingBox(vec2[] v)
        {
            vec4 result = new vec4();
            result.w = (float)Math.Floor(Math.Min(Math.Min(Math.Min(v[0].x, v[1].x), v[2].x), v[3].x)); // start.x
            result.x = (float)Math.Ceiling(Math.Max(Math.Max(Math.Max(v[0].x, v[1].x), v[2].x), v[3].x)); // end.x

            result.y = (float)Math.Floor(Math.Min(Math.Min(Math.Min(v[0].y, v[1].y), v[2].y), v[3].y)); // start.y
            result.z = (float)Math.Ceiling(Math.Max(Math.Max(Math.Max(v[0].y, v[1].y), v[2].y), v[3].y)); // end.y

            return result;
        }

        // Objective:   Load an elevation file
        // Input:       (short) x:          longitude integer coordinate
        //              (short) y:          latitude integer coordinate
        // Output:      (double) result:    elapsed time to load file
        public double loadFile(short x, short y)
        {
            DateTime start_time = DateTime.Now;

            // Get file name
            string fileName = getFilePath(x, y);

            if ((File.Exists(fileName)) && map[x + 180, y + 90] == null)
            {
                // Debug
                loadedFiles.Add(fileName);

                // Set buffer size
                // TODO: must check ideal buffer size of each system
                int bufferSize = 1024 * 256;

                byte[] buffer = new byte[bufferSize - 1 + 1];
                var fileInfo = new FileInfo(fileName);

                // Create an array for the elevation in the coordinate
                map[x + 180, y + 90] = new short[(int)(Math.Pow(DEFAULT_RESOLUTION, 2) + 1)];

                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    // Read line
                    for (int j = 0; j <= Math.Pow(DEFAULT_RESOLUTION, 2) - 1; j += bufferSize / 2)
                    {
                        // Read and process line buffer
                        fs.Read(buffer, 0, buffer.Length);
                        processFileBuffer(buffer, j, bufferSize, x, y);
                    }
                }

                // Return elapsed time
                return DateTime.Now.Subtract(start_time).TotalSeconds;
            }
            else
            {
                // Debug
                loadedFiles.Add(fileName + " (not found)");
                return 0;
            }

        }

        // Objective:   Get the elevation file path to load
        // Input:       (short) x:          longitude integer coordinate
        //              (short) y:          latitude integer coordinate
        // Output:      (string) result:    file path
        public static string getFilePath(short x, short y)
        {
            // The file name contains 
            string i_abs = Math.Abs(x).ToString();
            string j_abs = Math.Abs(y).ToString();

            while ((i_abs.Length < 3))
                i_abs = "0" + i_abs;
            while ((j_abs.Length < 2))
                j_abs = "0" + j_abs;

            string i = (x / (double)Math.Abs(x) < 0 ? "W" : "E") + i_abs;
            string j = (y / (double)Math.Abs(y) < 0 ? "S" : "N") + j_abs;

            return Application.StartupPath + "/hgts/" + j + i + ".hgt";
        }

        // Objective:   Process a line of bytes of an elevation file and convert it to short values of elevation
        // Input:       (byte[]) buffer:    byte buffer
        //              (int) j:            position of the first byte in the file
        //              (int) bufferSize:   amount of bytes to read per instance
        //              (short) x:          longitude integer coordinate
        //              (short) y:          latitude integer coordinate
        // Output:      (null)
        private void processFileBuffer(byte[] buffer, int j, int bufferSize, short x, short y)
        {
            for (int i = 0; i <= bufferSize - 1; i += 2)  // 16-bit signed int
            {
                // Don't process bytes outside of resolution limit
                if ((j + i / 2 > Math.Pow(DEFAULT_RESOLUTION, 2)))
                {
                    return;
                }

                // Select a part of the buffer and perform byte-swapping (buffer is Motorola big-endian)
                byte[] intBuffer = new byte[2] { buffer[i + 1], buffer[i] };

                // Convert the byte buffer into short and store into map variable
                map[x + 180, y + 90][j + i / 2] = BitConverter.ToInt16(intBuffer, 0);
            }
        }

        // Objective:   Load the elevation files based on the search rectangle
        // Input:       (vec2[]) rectangle:         search rectangle
        //              (short) addHeight:          value to add to the peak for safety reasons
        //              (short) addHeightMountaing: value to add to the peak if the difference between peak and valley is greater or equal to 1000
        // Output:      (short) result:             MSA of the rectangle in metres
        public short getMSA(vec2[] rectangle, short addHeight, short addHeightMountain)
        {
            vec2 peak = getPeakInRectangle(rectangle[0], rectangle[1], rectangle[2], rectangle[3]);

            short msa = (short)peak.y;
            if ((peak.y - peak.x >= HGT.feetToMetres(1000)))
                msa += (short)HGT.feetToMetres(addHeightMountain);
            else
                msa += (short)HGT.feetToMetres(addHeight);

            return msa;
        }

        // Objective:   Calculates the peak and the bottom of elevation in the rectangle
        // Input:       (vec2) v1:         vertice of the rectangle
        //              (vec2) v2:         vertice of the rectangle
        //              (vec2) v3:         vertice of the rectangle
        //              (vec2) v4:         vertice of the rectangle
        // Output:      (vec2) result:     peak and valley of the rectangle in metres
        public vec2 getPeakInRectangle(vec2 v1, vec2 v2, vec2 v3, vec2 v4)
        {

            // Get the bounding box of the rectangle
            vec4 boundingBox = getBoundingBox(new vec2[] { v1, v2, v3, v4 });

            vec2 peak = new vec2(999999, 0);
            int i = (int)((boundingBox.w - Math.Floor(boundingBox.w)) * DEFAULT_RESOLUTION);
            int j = (int)((boundingBox.x - Math.Floor(boundingBox.x)) * DEFAULT_RESOLUTION);
            for (double x = (short)boundingBox.w; x <= (short)boundingBox.x; x += (double)1 / DEFAULT_RESOLUTION)
            {
                i++;
                j = (int)((boundingBox.x - Math.Floor(boundingBox.x)) * DEFAULT_RESOLUTION);
                for (double y = (short)boundingBox.y; y <= (short)boundingBox.z; y += (double)1 / DEFAULT_RESOLUTION)
                {
                    j++;
                    // Get elevation of a coordinate

                    if ((isPointInTriangle(new vec2((float)x, (float)y), v1, v2, v3) || isPointInTriangle(new vec2((float)x, (float)y), v3, v4, v1)))
                    {
                        // Get elevation of a coordinate
                        short elevation = getElevation(x, y);

                        // Add elevation only if it's different than 0
                        if ((elevation != 0))
                        {
                            peak.x = (float)Math.Min(peak.x, elevation);

                        }
                        if (elevation > peak.y)
                        {
                            peak.y = (float)Math.Max(peak.y, elevation);
                            peakCoordinate = new vec2((float)x, (float)y);
                        }

                    }
                }
            }

            peak.x = Math.Max(0, peak.x);
            peak.y = Math.Max(0, peak.y);

            if (peak.x > peak.y)
            {
                peak.x = peak.y;
            }

            return peak;
        }

        public vec2 getPeakInRectangle(vec2[] rectangle)
        {
            return getPeakInRectangle(rectangle[0], rectangle[1], rectangle[2], rectangle[3]);
        }

        // Objective:   Checks if a given point is inside a triangle
        // Input:       (vec2) pt:         pt to be analyzed
        //              (vec2) v1:         vertice of the triangle
        //              (vec2) v2:         vertice of the triangle
        //              (vec2) v3:         vertice of the triangle
        // Output:      (bool) result:     is or is not inside the triangle
        public static bool isPointInTriangle(vec2 pt, vec2 v1, vec2 v2, vec2 v3)
        {
            double denominator = ((v2.y - v3.y) * (v1.x - v3.x) + (v3.x - v2.x) * (v1.y - v3.y));
            double a = ((v2.y - v3.y) * (pt.x - v3.x) + (v3.x - v2.x) * (pt.y - v3.y)) / denominator;
            double b = ((v3.y - v1.y) * (pt.x - v3.x) + (v1.x - v3.x) * (pt.y - v3.y)) / denominator;
            double c = 1 - a - b;

            return 0 <= a && a <= 1 && 0 <= b && b <= 1 && 0 <= c && c <= 1;
        }

        // Objective:   Gets the elevation of the given coordinate
        // Input:       (double) x:          longitude in degrees
        //              (double) y:          latitude in degrees
        // Output:      (short)  result:     elevation in metres
        public short getElevation(double x, double y)
        {
            // Gets the array indexes
            double i = Math.Floor((x - Math.Floor(x)) * 1200);
            double j = 1200 - Math.Floor((y - Math.Floor(y)) * 1200);

            // Don't get elevation if it's out of bounds
            int tileX = (int)Math.Floor(x) + 180;
            int tileY = (int)Math.Floor(y) + 90;
            int tileZ = (int)(i + j * DEFAULT_RESOLUTION);

            if (tileX < 0 || tileX >= map.GetLength(0) || tileY < 0 || tileY >= map.GetLength(1))
            {
                return 0;
            } else if (map[tileX, tileY] == null)
            {
                return 0;
            } else
            {
                return map[tileX, tileY][tileZ];
            }
        }

        public static double metresToFeet(double metre)
        {
            return metre * 3.28084;
        }

        public static double feetToMetres(double feet)
        {
            return feet / 3.28084;
        }
    }
}
