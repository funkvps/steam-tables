﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tablas_Vapor_ASME2
{
    public partial class Region2 : Form
    {
        public Region2()
        {
            InitializeComponent();
        }

        public Double v2_pT(Double p,Double T)
        {
            //Function v2_pT(ByVal p As Double, ByVal T As Double) As Double

            //Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //6 Equations for Region 2, Section. 6.1 Basic Equation
            //Table 11 and 12, Page 14 and 15

           
            Double tau, g0pi, grpi;

            Double R = 0.461526; //kJ/(kg K)

            Double[] J0 = new Double[] { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            Double[] n0 = new Double[] { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            Double[] Ir = new Double[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            Double[] Jr = new Double[] { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            Double[] nr = new Double[] { -1.7731742473213E-03, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -3.3032641670203E-05, -1.8948987516315E-04, -3.9392777243355E-03, -0.043797295650573, -2.6674547914087E-05, 2.0481737692309E-08, 4.3870667284435E-07, -3.227767723857E-05, -1.5033924542148E-03, -0.040668253562649, -7.8847309559367E-10, 1.2790717852285E-08, 4.8225372718507E-07, 2.2922076337661E-06, -1.6714766451061E-11, -2.1171472321355E-03, -23.895741934104, -5.905956432427E-18, -1.2621808899101E-06, -0.038946842435739, 1.1256211360459E-11, -8.2311340897998, 1.9809712802088E-08, 1.0406965210174E-19, -1.0234747095929E-13, -1.0018179379511E-09, -8.0882908646985E-11, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 3.0629316876232E-13, -4.2002467698208E-06, -5.9056029685639E-26, 3.7826947613457E-06, -1.2768608934681E-15, 7.3087610595061E-29, 5.5414715350778E-17, -9.436970724121E-07 };

            tau = 540 / T;
            g0pi = 1 / p;
            grpi = 0;

            for (int i = 0; i <= 42; i++)
            {
                grpi = grpi + nr[i] * Ir[i] * Math.Pow(p, (Ir[i] - 1)) * Math.Pow((tau - 0.5), Jr[i]);

            }

            return(R * T / p * p * (g0pi + grpi) / 1000);
 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Double p, T;
            p = 0;
            T = 0;

            p = Convert.ToDouble(textBox1.Text);
            T = Convert.ToDouble(textBox2.Text);
            textBox3.Text = Convert.ToString(v2_pT(p,T));

        }

        public Double h2_pT(Double p,Double T)
        {
            //Function h2_pT(ByVal p As Double, ByVal T As Double) As Double

            //Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //6 Equations for Region 2, Section. 6.1 Basic Equation
            //Table 11 and 12, Page 14 and 15
         
            Double tau, g0tau, grtau;

            Double R = 0.461526; //kJ/(kg K)

            Double[] J0 = new Double[] { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            Double[] n0 = new Double[] { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            Double[] Ir = new Double[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            Double[] Jr = new Double[] { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            Double[] nr = new Double[] { -1.7731742473213E-03, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -3.3032641670203E-05, -1.8948987516315E-04, -3.9392777243355E-03, -0.043797295650573, -2.6674547914087E-05, 2.0481737692309E-08, 4.3870667284435E-07, -3.227767723857E-05, -1.5033924542148E-03, -0.040668253562649, -7.8847309559367E-10, 1.2790717852285E-08, 4.8225372718507E-07, 2.2922076337661E-06, -1.6714766451061E-11, -2.1171472321355E-03, -23.895741934104, -5.905956432427E-18, -1.2621808899101E-06, -0.038946842435739, 1.1256211360459E-11, -8.2311340897998, 1.9809712802088E-08, 1.0406965210174E-19, -1.0234747095929E-13, -1.0018179379511E-09, -8.0882908646985E-11, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 3.0629316876232E-13, -4.2002467698208E-06, -5.9056029685639E-26, 3.7826947613457E-06, -1.2768608934681E-15, 7.3087610595061E-29, 5.5414715350778E-17, -9.436970724121E-07 };

           

            tau = 540 / T;

            g0tau = 0;

            for (int i = 0; i <= 8; i++)
            {

                g0tau = g0tau + n0[i] * J0[i] * Math.Pow(tau, (J0[i] - 1));

            }

            grtau = 0;

            for (int i = 0; i <= 42; i++)
            {

                grtau = grtau + nr[i] * Math.Pow(p, Ir[i]) * Jr[i] * Math.Pow((tau - 0.5), (Jr[i] - 1));

            }

           return(R * T * tau * (g0tau + grtau));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Double p, T;
            p = 0;
            T = 0;

            p = Convert.ToDouble(textBox6.Text);
            T = Convert.ToDouble(textBox5.Text);
            textBox4.Text = Convert.ToString(h2_pT(p,T));

        }


        public Double u2_pT(Double p,Double T)
        {

            //Function u2_pT(ByVal p As Double, ByVal T As Double) As Double
            //Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //6 Equations for Region 2, Section. 6.1 Basic Equation
            //Table 11 and 12, Page 14 and 15

            Double tau, g0tau, g0pi, grpi, grtau;

            Double R = 0.461526; //kJ/(kg K)

            Double[] J0 = new Double[] { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            Double[] n0 = new Double[] { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            Double[] Ir = new Double[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            Double[] Jr = new Double[] { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            Double[] nr = new Double[] { -1.7731742473213E-03, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -3.3032641670203E-05, -1.8948987516315E-04, -3.9392777243355E-03, -0.043797295650573, -2.6674547914087E-05, 2.0481737692309E-08, 4.3870667284435E-07, -3.227767723857E-05, -1.5033924542148E-03, -0.040668253562649, -7.8847309559367E-10, 1.2790717852285E-08, 4.8225372718507E-07, 2.2922076337661E-06, -1.6714766451061E-11, -2.1171472321355E-03, -23.895741934104, -5.905956432427E-18, -1.2621808899101E-06, -0.038946842435739, 1.1256211360459E-11, -8.2311340897998, 1.9809712802088E-08, 1.0406965210174E-19, -1.0234747095929E-13, -1.0018179379511E-09, -8.0882908646985E-11, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 3.0629316876232E-13, -4.2002467698208E-06, -5.9056029685639E-26, 3.7826947613457E-06, -1.2768608934681E-15, 7.3087610595061E-29, 5.5414715350778E-17, -9.436970724121E-07 };

            tau = 540 / T;
            g0pi = 1 / p;
            g0tau = 0;

            for (int i = 0; i <= 8; i++)
            {
                g0tau = g0tau + n0[i] * J0[i] * Math.Pow(tau, (J0[i] - 1));

            }

            grpi = 0;
            grtau = 0;

            for (int i = 0; i <= 42; i++)
            {

                grpi = grpi + nr[i] * Ir[i] * Math.Pow(p, (Ir[i] - 1)) * Math.Pow((tau - 0.5), Jr[i]);
                grtau = grtau + nr[i] * Math.Pow(p, Ir[i]) * Jr[i] * Math.Pow((tau - 0.5), (Jr[i] - 1));

            }

            return(R * T * (tau * (g0tau + grtau) - p * (g0pi + grpi)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Double p, T;
            p = 0;
            T = 0;

            p = Convert.ToDouble(textBox9.Text);
            T = Convert.ToDouble(textBox8.Text);
            textBox7.Text = Convert.ToString(u2_pT(p,T));
        }


        public Double s2_pT(Double p,Double T)
        {
            //Function s2_pT(ByVal p As Double, ByVal T As Double) As Double
            //Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //6 Equations for Region 2, Section. 6.1 Basic Equation
            //Table 11 and 12, Page 14 and 15

            Double tau, g0, g0tau, gr, grtau;

            Double R = 0.461526; //kJ/(kg K)

            Double[] J0 = new Double[] { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            Double[] n0 = new Double[] { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            Double[] Ir = new Double[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            Double[] Jr = new Double[] { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            Double[] nr = new Double[] { -1.7731742473213E-03, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -3.3032641670203E-05, -1.8948987516315E-04, -3.9392777243355E-03, -0.043797295650573, -2.6674547914087E-05, 2.0481737692309E-08, 4.3870667284435E-07, -3.227767723857E-05, -1.5033924542148E-03, -0.040668253562649, -7.8847309559367E-10, 1.2790717852285E-08, 4.8225372718507E-07, 2.2922076337661E-06, -1.6714766451061E-11, -2.1171472321355E-03, -23.895741934104, -5.905956432427E-18, -1.2621808899101E-06, -0.038946842435739, 1.1256211360459E-11, -8.2311340897998, 1.9809712802088E-08, 1.0406965210174E-19, -1.0234747095929E-13, -1.0018179379511E-09, -8.0882908646985E-11, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 3.0629316876232E-13, -4.2002467698208E-06, -5.9056029685639E-26, 3.7826947613457E-06, -1.2768608934681E-15, 7.3087610595061E-29, 5.5414715350778E-17, -9.436970724121E-07 };

            tau = 540 / T;
            g0 = Math.Log(p);
            g0tau = 0;

            for (int i = 0; i <= 8; i++)
            {
                g0 = g0 + n0[i] * Math.Pow(tau, J0[i]);
                g0tau = g0tau + n0[i] * J0[i] * Math.Pow(tau, (J0[i] - 1));
            }

            gr = 0;
            grtau = 0;

            for (int i = 0; i <= 42; i++)
            {
                gr = gr + nr[i] * Math.Pow(p, Ir[i]) * Math.Pow((tau - 0.5), Jr[i]);
                grtau = grtau + nr[i] * Math.Pow(p, Ir[i]) * Jr[i] * Math.Pow((tau - 0.5), (Jr[i] - 1));
            }

            return(R * (tau * (g0tau + grtau) - (g0 + gr)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Double p,T;
            p=0;
            T=0;

            p = Convert.ToDouble(textBox12.Text);
            T = Convert.ToDouble(textBox11.Text);
            textBox10.Text = Convert.ToString(s2_pT(p,T));
           
        }

        public Double Cp2_pT(Double p, Double T)
        {
            //Function Cp2_pT(ByVal p As Double, ByVal T As Double) As Double
            //Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //6 Equations for Region 2, Section. 6.1 Basic Equation
            //Table 11 and 12, Page 14 and 15

            Double tau, g0tautau, grtautau;

            Double R = 0.461526; //kJ/(kg K)

            Double[] J0 = new Double[] { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            Double[] n0 = new Double[] { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            Double[] Ir = new Double[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            Double[] Jr = new Double[] { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            Double[] nr = new Double[] { -1.7731742473213E-03, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -3.3032641670203E-05, -1.8948987516315E-04, -3.9392777243355E-03, -0.043797295650573, -2.6674547914087E-05, 2.0481737692309E-08, 4.3870667284435E-07, -3.227767723857E-05, -1.5033924542148E-03, -0.040668253562649, -7.8847309559367E-10, 1.2790717852285E-08, 4.8225372718507E-07, 2.2922076337661E-06, -1.6714766451061E-11, -2.1171472321355E-03, -23.895741934104, -5.905956432427E-18, -1.2621808899101E-06, -0.038946842435739, 1.1256211360459E-11, -8.2311340897998, 1.9809712802088E-08, 1.0406965210174E-19, -1.0234747095929E-13, -1.0018179379511E-09, -8.0882908646985E-11, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 3.0629316876232E-13, -4.2002467698208E-06, -5.9056029685639E-26, 3.7826947613457E-06, -1.2768608934681E-15, 7.3087610595061E-29, 5.5414715350778E-17, -9.436970724121E-07 };

            tau = 540 / T;
            g0tautau = 0;

            for (int i = 0; i <= 8; i++)
            {
                g0tautau = g0tautau + n0[i] * J0[i] * (J0[i] - 1) * Math.Pow(tau, (J0[i] - 2));
            }

            grtautau = 0;

            for (int i = 0; i <= 42; i++)
            {
                grtautau = grtautau + nr[i] * Math.Pow(p, Ir[i]) * Jr[i] * (Jr[i] - 1) * Math.Pow((tau - 0.5), (Jr[i] - 2));
            }

            return(-R * Math.Pow(tau, 2) * (g0tautau + grtautau));

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Double p, T;
            p = 0;
            T = 0;

            p = Convert.ToDouble(textBox15.Text);
            T = Convert.ToDouble(textBox14.Text);
            textBox13.Text = Convert.ToString(Cp2_pT(p,T));
        }

        public Double Cv2_pT(Double p,Double T)
        {
            //Function Cv2_pT(ByVal p As Double, ByVal T As Double) As Double

            Double tau, g0tautau, grpi, grpitau, grpipi, grtautau;

            Double R = 0.461526;//kJ/(kg K)

            Double[] J0 = new Double[] { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            Double[] n0 = new Double[] { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            Double[] Ir = new Double[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            Double[] Jr = new Double[] { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            Double[] nr = new Double[] { -1.7731742473213E-03, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -3.3032641670203E-05, -1.8948987516315E-04, -3.9392777243355E-03, -0.043797295650573, -2.6674547914087E-05, 2.0481737692309E-08, 4.3870667284435E-07, -3.227767723857E-05, -1.5033924542148E-03, -0.040668253562649, -7.8847309559367E-10, 1.2790717852285E-08, 4.8225372718507E-07, 2.2922076337661E-06, -1.6714766451061E-11, -2.1171472321355E-03, -23.895741934104, -5.905956432427E-18, -1.2621808899101E-06, -0.038946842435739, 1.1256211360459E-11, -8.2311340897998, 1.9809712802088E-08, 1.0406965210174E-19, -1.0234747095929E-13, -1.0018179379511E-09, -8.0882908646985E-11, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 3.0629316876232E-13, -4.2002467698208E-06, -5.9056029685639E-26, 3.7826947613457E-06, -1.2768608934681E-15, 7.3087610595061E-29, 5.5414715350778E-17, -9.436970724121E-07 };

            tau = 540 / T;
            g0tautau = 0;

            for (int i = 0; i <= 8; i++)
            {
                g0tautau = g0tautau + n0[i] * J0[i] * (J0[i] - 1) * Math.Pow(tau, (J0[i] - 2));
            }

            grpi = 0;
            grpitau = 0;
            grpipi = 0;
            grtautau = 0;

            for (int i = 0; i <= 42; i++)
            {
                grpi = grpi + nr[i] * Ir[i] * Math.Pow(p, (Ir[i] - 1)) * Math.Pow((tau - 0.5), Jr[i]);
                grpipi = grpipi + nr[i] * Ir[i] * (Ir[i] - 1) * Math.Pow(p, (Ir[i] - 2)) * Math.Pow((tau - 0.5), Jr[i]);
                grpitau = grpitau + nr[i] * Ir[i] * Math.Pow(p, (Ir[i] - 1)) * Jr[i] * Math.Pow((tau - 0.5), (Jr[i] - 1));
                grtautau = grtautau + nr[i] * Math.Pow(p, Ir[i]) * Jr[i] * (Jr[i] - 1) * Math.Pow((tau - 0.5), (Jr[i] - 2));
            }

           return(R * (-(Math.Pow(tau, 2) * (g0tautau + grtautau)) - (Math.Pow((1 + p * grpi - tau * p * grpitau), 2)) / (1 - Math.Pow(p, 2) * grpipi)));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Double p,T;
            p=0;
            T=0;

            p = Convert.ToDouble(textBox18.Text);
            T = Convert.ToDouble(textBox17.Text);
            textBox16.Text = Convert.ToString(Cv2_pT(p,T));
        }

        public Double w2_pT(Double p,Double T)
        {
            //Function w2_pT(ByVal p As Double, ByVal T As Double) As Double
            //Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //6 Equations for Region 2, Section. 6.1 Basic Equation
            //Table 11 and 12, Page 14 and 15

            Double tau, g0tautau, grpi, grpitau, grpipi, grtautau;

            Double R = 0.461526; //kJ/(kg K)

            Double[] J0 = new Double[] { 0, 1, -5, -4, -3, -2, -1, 2, 3 };
            Double[] n0 = new Double[] { -9.6927686500217, 10.086655968018, -0.005608791128302, 0.071452738081455, -0.40710498223928, 1.4240819171444, -4.383951131945, -0.28408632460772, 0.021268463753307 };
            Double[] Ir = new Double[] { 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 10, 10, 10, 16, 16, 18, 20, 20, 20, 21, 22, 23, 24, 24, 24 };
            Double[] Jr = new Double[] { 0, 1, 2, 3, 6, 1, 2, 4, 7, 36, 0, 1, 3, 6, 35, 1, 2, 3, 7, 3, 16, 35, 0, 11, 25, 8, 36, 13, 4, 10, 14, 29, 50, 57, 20, 35, 48, 21, 53, 39, 26, 40, 58 };
            Double[] nr = new Double[] { -1.7731742473213E-03, -0.017834862292358, -0.045996013696365, -0.057581259083432, -0.05032527872793, -3.3032641670203E-05, -1.8948987516315E-04, -3.9392777243355E-03, -0.043797295650573, -2.6674547914087E-05, 2.0481737692309E-08, 4.3870667284435E-07, -3.227767723857E-05, -1.5033924542148E-03, -0.040668253562649, -7.8847309559367E-10, 1.2790717852285E-08, 4.8225372718507E-07, 2.2922076337661E-06, -1.6714766451061E-11, -2.1171472321355E-03, -23.895741934104, -5.905956432427E-18, -1.2621808899101E-06, -0.038946842435739, 1.1256211360459E-11, -8.2311340897998, 1.9809712802088E-08, 1.0406965210174E-19, -1.0234747095929E-13, -1.0018179379511E-09, -8.0882908646985E-11, 0.10693031879409, -0.33662250574171, 8.9185845355421E-25, 3.0629316876232E-13, -4.2002467698208E-06, -5.9056029685639E-26, 3.7826947613457E-06, -1.2768608934681E-15, 7.3087610595061E-29, 5.5414715350778E-17, -9.436970724121E-07 };

            tau = 540 / T;
            g0tautau = 0;

            for (int i = 0; i <= 8; i++)
            {
                g0tautau = g0tautau + n0[i] * J0[i] * (J0[i] - 1) * Math.Pow(tau, (J0[i] - 2));
            }

            grpi = 0;
            grpitau = 0;
            grpipi = 0;
            grtautau = 0;

            for (int i = 0; i <= 42; i++)
            {
                grpi = grpi + nr[i] * Ir[i] * Math.Pow(p, (Ir[i] - 1)) * Math.Pow((tau - 0.5), Jr[i]);
                grpipi = grpipi + nr[i] * Ir[i] * (Ir[i] - 1) * Math.Pow(p, (Ir[i] - 2)) * Math.Pow((tau - 0.5), Jr[i]);
                grpitau = grpitau + nr[i] * Ir[i] * Math.Pow(p, (Ir[i] - 1)) * Jr[i] * Math.Pow((tau - 0.5), (Jr[i] - 1));
                grtautau = grtautau + nr[i] * Math.Pow(p, Ir[i]) * Jr[i] * (Jr[i] - 1) * Math.Pow((tau - 0.5), (Jr[i] - 2));

            }

            return(Math.Pow((1000 * R * T * (1 + 2 * p * grpi + Math.Pow(p, 2) * Math.Pow(grpi, 2)) / ((1 - Math.Pow(p, 2) * grpipi) + Math.Pow((1 + p * grpi - tau * p * grpitau), 2) / (Math.Pow(tau, 2) * (g0tautau + grtautau)))), 0.5));

        }


        private void button7_Click(object sender, EventArgs e)
        {
            Double p, T;
            p = 0;
            T = 0;

            p = Convert.ToDouble(textBox21.Text);
            T = Convert.ToDouble(textBox20.Text);

            textBox19.Text = Convert.ToString(w2_pT(p,T));
        }

        public Double T2_ph(Double p, Double h)
        {
            //Function T2_ph(ByVal p As Double, ByVal h As Double) As Double
            //Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //6 Equations for Region 2,6.3.1 The Backward Equations T( p, h ) for Subregions 2a, 2b, and 2c          

            Int32 subreg;

            Double Ts, hs;

            if (p < 4)
            {
                subreg = 1;
            }
            else
            {
                if (p < (905.84278514723 - 0.67955786399241 * h + 1.2809002730136E-04 * Math.Pow(h, 2)))
                {
                    subreg = 2;
                }
                else
                {
                    subreg = 3;
                }
            }

            switch (subreg)
            {
                case 1:

                    //Subregion A
                    //Table 20, Eq 22, page 22

                    Double[] Ji = new Double[] { 0, 1, 2, 3, 7, 20, 0, 1, 2, 3, 7, 9, 11, 18, 44, 0, 2, 7, 36, 38, 40, 42, 44, 24, 44, 12, 32, 44, 32, 36, 42, 34, 44, 28 };
                    Double[] Ii = new Double[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7 };
                    Double[] ni = new Double[] { 1089.8952318288, 849.51654495535, -107.81748091826, 33.153654801263, -7.4232016790248, 11.765048724356, 1.844574935579, -4.1792700549624, 6.2478196935812, -17.344563108114, -200.58176862096, 271.96065473796, -455.11318285818, 3091.9688604755, 252266.40357872, -6.1707422868339E-03, -0.31078046629583, 11.670873077107, 128127984.04046, -985549096.23276, 2822454697.3002, -3594897141.0703, 1722734991.3197, -13551.334240775, 12848734.66465, 1.3865724283226, 235988.32556514, -13105236.545054, 7399.9835474766, -551966.9703006, 3715408.5996233, 19127.72923966, -415351.64835634, -62.459855192507 };

                    Ts = 0;
                    hs = h / 2000;

                    for (int i = 0; i <= 33; i++)
                    {
                        Ts = Ts + ni[i] * Math.Pow(p, (Ii[i])) * Math.Pow((hs - 2.1), Ji[i]);
                    }

                    return(Ts);

                    break;

                case 2:

                    //Subregion B
                    //Table 21, Eq 23, page 23
                    Double[] Jhi = new Double[] { 0, 1, 2, 12, 18, 24, 28, 40, 0, 2, 6, 12, 18, 24, 28, 40, 2, 8, 18, 40, 1, 2, 12, 24, 2, 12, 18, 24, 28, 40, 18, 24, 40, 28, 2, 28, 1, 40 };
                    Double[] Ihi = new Double[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 5, 6, 7, 7, 9, 9 };
                    Double[] nhi = new Double[] { 1489.5041079516, 743.07798314034, -97.708318797837, 2.4742464705674, -0.63281320016026, 1.1385952129658, -0.47811863648625, 8.5208123431544E-03, 0.93747147377932, 3.3593118604916, 3.3809355601454, 0.16844539671904, 0.73875745236695, -0.47128737436186, 0.15020273139707, -0.002176411421975, -0.021810755324761, -0.10829784403677, -0.046333324635812, 7.1280351959551E-05, 1.1032831789999E-04, 1.8955248387902E-04, 3.0891541160537E-03, 1.3555504554949E-03, 2.8640237477456E-07, -1.0779857357512E-05, -7.6462712454814E-05, 1.4052392818316E-05, -3.1083814331434E-05, -1.0302738212103E-06, 2.821728163504E-07, 1.2704902271945E-06, 7.3803353468292E-08, -1.1030139238909E-08, -8.1456365207833E-14, -2.5180545682962E-11, -1.7565233969407E-18, 8.6934156344163E-15 };

                    Ts = 0;
                    hs = h / 2000;

                    for (int i = 0; i <= 37; i++)
                    {
                        Ts = Ts + nhi[i] * Math.Pow((p - 2), (Ihi[i])) * Math.Pow((hs - 2.6), Jhi[i]);
                    }

                    return(Ts);

                    break;

                default:

                    //Subregion C
                    //Table 22, Eq 24, page 24
                    Double[] Jli = new Double[] { 0, 4, 0, 2, 0, 2, 0, 1, 0, 2, 0, 1, 4, 8, 4, 0, 1, 4, 10, 12, 16, 20, 22 };
                    Double[] Ili = new Double[] { -7, -7, -6, -6, -5, -5, -2, -2, -1, -1, 0, 0, 1, 1, 2, 6, 6, 6, 6, 6, 6, 6, 6 };
                    Double[] nli = new Double[] { -3236839855524.2, 7326335090218.1, 358250899454.47, -583401318515.9, -10783068217.47, 20825544563.171, 610747.83564516, 859777.2253558, -25745.72360417, 31081.088422714, 1208.2315865936, 482.19755109255, 3.7966001272486, -10.842984880077, -0.04536417267666, 1.4559115658698E-13, 1.126159740723E-12, -1.7804982240686E-11, 1.2324579690832E-07, -1.1606921130984E-06, 2.7846367088554E-05, -5.9270038474176E-04, 1.2918582991878E-03 };

                    Ts = 0;
                    hs = h / 2000;

                    for (int i = 0; i <= 22; i++)
                    {
                        Ts = Ts + nli[i] * Math.Pow((p + 25), (Ili[i])) * Math.Pow((hs - 1.8), Jli[i]);
                    }

                    return(Ts);

                    break;

            }

        }


        private void button8_Click(object sender, EventArgs e)
        {
            Double p, h;
            p = 0;
            h = 0;

            p = Convert.ToDouble(textBox24.Text);
            h = Convert.ToDouble(textBox23.Text);

            textBox22.Text = Convert.ToString(T2_ph(p,h));
       
        }

        public Double T2_ps(Double p, Double s)
        {
            //Function T2_ps(ByVal p As Double, ByVal s As Double) As Double
            //Release on the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam, September 1997
            //6 Equations for Region 2,6.3.2 The Backward Equations T( p, s ) for Subregions 2a, 2b, and 2c
            //Page 26

            Int32 subreg;

            Double teta, sigma;

            if (p < 4)
            {
                subreg = 1;
            }
            else
            {
                if (s < 5.85)
                {
                    subreg = 3;
                }
                else
                {
                    subreg = 2;

                }
            }

            switch (subreg)
            {
                case 1:
                    //Subregion A
                    //Table 25, Eq 25, page 26

                    Double[] Ii = new Double[] { -1.5, -1.5, -1.5, -1.5, -1.5, -1.5, -1.25, -1.25, -1.25, -1, -1, -1, -1, -1, -1, -0.75, -0.75, -0.5, -0.5, -0.5, -0.5, -0.25, -0.25, -0.25, -0.25, 0.25, 0.25, 0.25, 0.25, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.75, 0.75, 0.75, 0.75, 1, 1, 1.25, 1.25, 1.5, 1.5 };
                    Double[] Ji = new Double[] { -24, -23, -19, -13, -11, -10, -19, -15, -6, -26, -21, -17, -16, -9, -8, -15, -14, -26, -13, -9, -7, -27, -25, -11, -6, 1, 4, 8, 11, 0, 1, 5, 6, 10, 14, 16, 0, 4, 9, 17, 7, 18, 3, 15, 5, 18 };
                    Double[] ni = new Double[] { -392359.83861984, 515265.7382727, 40482.443161048, -321.93790923902, 96.961424218694, -22.867846371773, -449429.14124357, -5011.8336020166, 0.35684463560015, 44235.33584819, -13673.388811708, 421632.60207864, 22516.925837475, 474.42144865646, -149.31130797647, -197811.26320452, -23554.39947076, -19070.616302076, 55375.669883164, 3829.3691437363, -603.91860580567, 1936.3102620331, 4266.064369861, -5978.0638872718, -704.01463926862, 338.36784107553, 20.862786635187, 0.033834172656196, -4.3124428414893E-05, 166.53791356412, -139.86292055898, -0.78849547999872, 0.072132411753872, -5.9754839398283E-03, -1.2141358953904E-05, 2.3227096733871E-07, -10.538463566194, 2.0718925496502, -0.072193155260427, 2.074988708112E-07, -0.018340657911379, 2.9036272348696E-07, 0.21037527893619, 2.5681239729999E-04, -0.012799002933781, -8.2198102652018E-06 };

                    sigma = s / 2;
                    teta = 0;

                    for (int i = 0; i <= 45; i++)
                    {

                        teta = teta + ni[i] * Math.Pow(p, Ii[i]) * Math.Pow((sigma - 2), Ji[i]);

                    }

                    return(teta);

                    break;

                case 2:
                    //Subregion B
                    //Table 26, Eq 26, page 27

                    Double[] Iai = new Double[] { -6, -6, -5, -5, -4, -4, -4, -3, -3, -3, -3, -2, -2, -2, -2, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 5, 5, 5 };
                    Double[] Jai = new Double[] { 0, 11, 0, 11, 0, 1, 11, 0, 1, 11, 12, 0, 1, 6, 10, 0, 1, 5, 8, 9, 0, 1, 2, 4, 5, 6, 9, 0, 1, 2, 3, 7, 8, 0, 1, 5, 0, 1, 3, 0, 1, 0, 1, 2 };
                    Double[] nai = new Double[] { 316876.65083497, 20.864175881858, -398593.99803599, -21.816058518877, 223697.85194242, -2784.1703445817, 9.920743607148, -75197.512299157, 2970.8605951158, -3.4406878548526, 0.38815564249115, 17511.29508575, -1423.7112854449, 1.0943803364167, 0.89971619308495, -3375.9740098958, 471.62885818355, -1.9188241993679, 0.41078580492196, -0.33465378172097, 1387.0034777505, -406.63326195838, 41.72734715961, 2.1932549434532, -1.0320050009077, 0.35882943516703, 5.2511453726066E-03, 12.838916450705, -2.8642437219381, 0.56912683664855, -0.099962954584931, -3.2632037778459E-03, 2.3320922576723E-04, -0.1533480985745, 0.029072288239902, 3.7534702741167E-04, 1.7296691702411E-03, -3.8556050844504E-04, -3.5017712292608E-05, -1.4566393631492E-05, 5.6420857267269E-06, 4.1286150074605E-08, -2.0684671118824E-08, 1.6409393674725E-09 };

                    sigma = s / 0.7853;

                    teta = 0;

                    for (int i = 0; i <= 43; i++)
                    {

                        teta = teta + nai[i] * Math.Pow(p, Iai[i]) * Math.Pow((10 - sigma), Jai[i]);

                    }

                    return(teta);

                    break;

                default:
                    //Subregion C
                    //Table 27, Eq 27, page 28

                    Double[] Ibi = new Double[] { -2, -2, -1, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7, 7, 7, 7, 7 };
                    Double[] Jbi = new Double[] { 0, 1, 0, 0, 1, 2, 3, 0, 1, 3, 4, 0, 1, 2, 0, 1, 5, 0, 1, 4, 0, 1, 2, 0, 1, 0, 1, 3, 4, 5 };
                    Double[] nbi = new Double[] { 909.68501005365, 2404.566708842, -591.6232638713, 541.45404128074, -270.98308411192, 979.76525097926, -469.66772959435, 14.399274604723, -19.104204230429, 5.3299167111971, -21.252975375934, -0.3114733441376, 0.60334840894623, -0.042764839702509, 5.8185597255259E-03, -0.014597008284753, 5.6631175631027E-03, -7.6155864584577E-05, 2.2440342919332E-04, -1.2561095013413E-05, 6.3323132660934E-07, -2.0541989675375E-06, 3.6405370390082E-08, -2.9759897789215E-09, 1.0136618529763E-08, 5.9925719692351E-12, -2.0677870105164E-11, -2.0874278181886E-11, 1.0162166825089E-10, -1.6429828281347E-10 };

                    sigma = s / 2.9251;

                    teta = 0;

                    for (int i = 0; i <= 29; i++)
                    {
                        teta = teta + nbi[i] * Math.Pow(p, Ibi[i]) * Math.Pow((2 - sigma), Jbi[i]);
                    }

                    return(teta);
                    break;
            }        
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Double p,s;
            p=0;
            s=0;
            p = Convert.ToDouble(textBox27.Text);
            s = Convert.ToDouble(textBox26.Text);

            textBox25.Text = Convert.ToString(T2_ps(p,s));
            
        }

        public Double p2_hs(Double h,Double s)
        {
            //Function p2_hs(ByVal h As Double, ByVal s As Double) As Double
            //Supplementary Release on Backward Equations for Pressure as a Function of Enthalpy and Entropy p(h,s) to the IAPWS Industrial Formulation 1997 for the Thermodynamic Properties of Water and Steam
            //'Chapter 6:Backward Equations p(h,s) for Region 2

            Int16 subreg;

            Double eta, teta, sigma, p;

            if (h < (-3498.98083432139 + 2575.60716905876 * s - 421.073558227969 * Math.Pow(s, 2) + 27.6349063799944 * Math.Pow(s, 3)))
            {
                subreg = 1;
            }

            else
            {
                if (s < 5.85)
                {
                    subreg = 3;
                }
                else
                {
                    subreg = 2;
                }
            }

            switch (subreg)
            {

                case 1:

                    //Subregion A
                    //Table 6, Eq 3, page 8

                    Double[] Ii = new Double[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 3, 4, 5, 5, 6, 7 };
                    Double[] Ji = new Double[] { 1, 3, 6, 16, 20, 22, 0, 1, 2, 3, 5, 6, 10, 16, 20, 22, 3, 16, 20, 0, 2, 3, 6, 16, 16, 3, 16, 3, 1 };
                    Double[] ni = new Double[] { -1.82575361923032E-02, -0.125229548799536, 0.592290437320145, 6.04769706185122, 238.624965444474, -298.639090222922, 0.051225081304075, -0.437266515606486, 0.413336902999504, -5.16468254574773, -5.57014838445711, 12.8555037824478, 11.414410895329, -119.504225652714, -2847.7798596156, 4317.57846408006, 1.1289404080265, 1974.09186206319, 1516.12444706087, 1.41324451421235E-02, 0.585501282219601, -2.97258075863012, 5.94567314847319, -6236.56565798905, 9659.86235133332, 6.81500934948134, -6332.07286824489, -5.5891922446576, 4.00645798472063E-02 };

                    eta = h / 4200;

                    sigma = s / 12;

                    p = 0;

                    for (int i = 0; i <= 28; i++)
                    {
                        p = p + ni[i] * Math.Pow((eta - 0.5), Ii[i]) * Math.Pow((sigma - 1.2), Ji[i]);

                    }

                    return(Math.Pow(p, 4) * 4);

                    break;

                case 2:

                    //Subregion B
                    //Table 7, Eq 4, page 9

                    Double[] Ici = new Double[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 5, 5, 6, 6, 6, 7, 7, 8, 8, 8, 8, 12, 14 };
                    Double[] Jci = new Double[] { 0, 1, 2, 4, 8, 0, 1, 2, 3, 5, 12, 1, 6, 18, 0, 1, 7, 12, 1, 16, 1, 12, 1, 8, 18, 1, 16, 1, 3, 14, 18, 10, 16 };
                    Double[] nci = new Double[] { 8.01496989929495E-02, -0.543862807146111, 0.337455597421283, 8.9055545115745, 313.840736431485, 0.797367065977789, -1.2161697355624, 8.72803386937477, -16.9769781757602, -186.552827328416, 95115.9274344237, -18.9168510120494, -4334.0703719484, 543212633.012715, 0.144793408386013, 128.024559637516, -67230.9534071268, 33697238.0095287, -586.63419676272, -22140322476.9889, 1716.06668708389, -570817595.806302, -3121.09693178482, -2078413.8463301, 3056059461577.86, 3221.57004314333, 326810259797.295, -1441.04158934487, 410.694867802691, 109077066873.024, -24796465425889.3, 1888019068.65134, -123651009018773 };

                    eta = h / 4100;

                    sigma = s / 7.9;

                    p = 0;

                    for (int i = 0; i <= 32; i++)
                    {
                        p = p + nci[i] * Math.Pow((eta - 0.6), Ici[i]) * Math.Pow((sigma - 1.01), Jci[i]);
                    }

                    return(Math.Pow(p, 4) * 100);

                    break;

                default:

                    //Subregion C
                    //Table 8, Eq 5, page 10

                    Double[] Idi = new Double[] { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 5, 5, 5, 5, 6, 6, 10, 12, 16 };
                    Double[] Jdi = new Double[] { 0, 1, 2, 3, 4, 8, 0, 2, 5, 8, 14, 2, 3, 7, 10, 18, 0, 5, 8, 16, 18, 18, 1, 4, 6, 14, 8, 18, 7, 7, 10 };
                    Double[] ndi = new Double[] { 0.112225607199012, -3.39005953606712, -32.0503911730094, -197.5973051049, -407.693861553446, 13294.3775222331, 1.70846839774007, 37.3694198142245, 3581.44365815434, 423014.446424664, -751071025.760063, 52.3446127607898, -228.351290812417, -960652.417056937, -80705929.2526074, 1626980172256.69, 0.772465073604171, 46392.9973837746, -13731788.5134128, 1704703926305.12, -25110462818730.8, 31774883083552, 53.8685623675312, -55308.9094625169, -1028615.22421405, 2042494187562.34, 273918446.626977, -2.63963146312685E+15, -1078908541.08088, -29649262098.0124, -1.11754907323424E+15 };

                    eta = h / 3500;

                    sigma = s / 5.9;

                    p = 0;

                    for (int i = 0; i <= 30; i++)
                    {
                        p = p + ndi[i] * Math.Pow((eta - 0.7), Idi[i]) * Math.Pow((sigma - 1.1), Jdi[i]);
                    }

                    return(Math.Pow(p, 4) * 100);

                    break;

            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            Double h, s;
            
            h = 0;
            s = 0;


            h = Convert.ToDouble(textBox30.Text);
            s = Convert.ToDouble(textBox29.Text);

            textBox29.Text = Convert.ToString(p2_hs(h,s));
        }

    }
}
