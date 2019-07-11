using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HashcodeTeamMak
{
    class Program
    {
        //TeamMak
        static void Main(string[] args)
        {

            List<Image> listofHImages = new List<Image>();
            List<Image> NomatchlistofHImages = new List<Image>();
            List<Image> NomatchlistofVImages = new List<Image>();
            List<Image> listofVImages = new List<Image>();
            int position = 0;

            //Reading the pics and categorising them into a list of objects.
            string[] lines = File.ReadAllLines(@"C:\Users\TMJ-12\Desktop\google Hash\b_lovely_landscapes.txt");
            List<string> slideslines = new List<string>();
            decimal picsNo;
            foreach (var line in lines)
            {
                var firstValue = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (firstValue.Length == 1)
                {
                    picsNo = decimal.Parse(firstValue[0]);
                }
                else if (firstValue.Length > 1)

                {
                    Image ImagesCurrent = new Image();

                    string hov = firstValue[0];
                    decimal tagsno = decimal.Parse(firstValue[1]);
                    ImagesCurrent.hov = hov;
                    ImagesCurrent.position = position;
                    ImagesCurrent.tagsno = tagsno;

                    for (int i = 2; i < firstValue.Length; i++)
                    {
                        ImagesCurrent.listoftags.Add(firstValue[i]);

                    }
                    if (hov == "H")
                    {
                        listofHImages.Add(ImagesCurrent);
                    }
                    else if (hov == "V")
                    {
                        listofVImages.Add(ImagesCurrent);
                    }


                    position++;
                }
            }

            int contd = 0;
            bool matchfound = false;
            slideslines.Add("");
            Image Currentslide = new Image();
            Image Mostcommon = new Image();
            Image dup = new Image();
            Mostcommon.count = 0;
            Currentslide = listofHImages[0];

            slideslines.Add(Currentslide.position.ToString());
            int ctrl = 0;
            while (listofHImages.Count > 0)
            {
                try
                {
                    for (int i = 1; i < listofHImages.Count; i++)
                    {
                        foreach (var tags in listofHImages[i].listoftags)
                        {
                            foreach (var tags2 in Currentslide.listoftags)
                            {
                                // || tags.ToString().Equals(tags2.ToString())
                                if (tags.ToString().Equals(tags2.ToString()))
                                {
                                    matchfound = true;
                                    contd = contd + 1;
                                    listofHImages[i].count = contd;
                                    dup = listofHImages[i];
                                }
                            }
                        }
                        dup = listofHImages[i];
                        if (listofHImages[i].count > Mostcommon.count )
                        {
                            //Mostcommon = listofHImages[i];
                         
                            Mostcommon = listofHImages.Find(x => x.position.Equals(listofHImages[i].position));
                            contd = 0;
                        }
                        else
                        {
                            contd = 0;
                           
                        }
                        listofHImages[i].count = 0;
                    }


                    if (matchfound == true)
                    {
                        Currentslide = listofHImages.Find(x => x.position.Equals(Mostcommon.position));
                        slideslines.Add(Mostcommon.position.ToString());
                        int pi = slideslines.Count - 1;
                        slideslines[0] = pi.ToString();
                        listofHImages.Remove(Currentslide);
                        File.WriteAllLines(@"C:\Users\TMJ-12\Desktop\google Hash\paul.txt", slideslines);
                        matchfound = false;
                        Mostcommon = new Image();
                        Mostcommon.count = 0;
                        ctrl = 0;
                    }
                    else
                    {
                        Mostcommon = new Image();
                        Mostcommon.count = 0;
                    }
                    if (matchfound == false&&ctrl>2)
                        {
                            listofHImages.Remove(Currentslide);
                           Currentslide = listofHImages[1]; ;
                           ctrl = 0;

                        }
                        ctrl++;
                }
                    catch (Exception e)
                {


                }
            }

        }
    }
}
