namespace LibraryEllipticIntegrals20dec2023
{
    /// <summary>
    /// see SolutionCsharp13dec2023
    /// https://en.wikipedia.org/wiki/Elliptic_integral
    /// Numerical Recipes in C++
    /// </summary>
    public class EllipticIntegralCalculator20dec2023
    {
        /// <summary>
        /// Legendre elliptic integral of the first kind F(phi, k), evaluated using Carlson's function R_F. The argument ranges are 0 <= phi <= pi/2, 0 <= k sin phi <= 1.
        /// </summary>
        /// <param name="phi"></param>
        /// <param name="ak"></param>
        /// <returns></returns>
        public double ellf(double phi, double ak)
        {
            double s = Math.Sin(phi);
            return s * rf(Math.Pow(Math.Cos(phi), 2), (1.0 - s * ak) * (1.0 + s * ak), 1.0);
        }

        /// <summary>
        /// Elliptic integral of the second kind
        /// </summary>
        /// <param name="phi"></param>
        /// <param name="ak"></param>
        /// <returns></returns>
        public double elle(double phi, double ak)
        {
            double cc, q, s;
            s = Math.Sin(phi);
            cc = Math.Pow(Math.Cos(phi), 2);
            q = (1.0 - s * ak) * (1.0 + s * ak);
            return s * (rf(cc, q, 1.0) - (Math.Pow(s * ak, 2)) * rd(cc, q, 1.0) / 3.0);
        }

        private double rc(double x, double y)
        {
            double ERRTOL = 0.0012, THIRD = 1.0 / 3.0, C1 = 0.3, C2 = 1.0 / 7.0, C3 = 0.375, C4 = 9.0 / 22.0;

            double TINY = 5.0 * double.MinValue, BIG = 0.2 * double.MaxValue, COMP1 = 2.236 / Math.Sqrt(TINY), COMP2 = Math.Pow(TINY * BIG, 2) / 25.0;

            double alamb, ave, s, w, xt, yt;

            if (x < 0.0 || y == 0.0 || (x + Math.Abs(y)) < TINY || (x + Math.Abs(y)) > BIG ||
                (y < -COMP1 && x > 0.0 && x < COMP2)) Console.WriteLine("invalid arguments in rc");
            if (y > 0.0)
            {
                xt = x;
                yt = y;
                w = 1.0;
            }
            else
            {
                xt = x - y;
                yt = -y;
                w = Math.Sqrt(x) / Math.Sqrt(xt);
            }
            do
            {
                alamb = 2.0 * Math.Sqrt(xt) * Math.Sqrt(yt) + yt;
                xt = 0.25 * (xt + alamb);
                yt = 0.25 * (yt + alamb);
                ave = THIRD * (xt + yt + yt);
                s = (yt - ave) / ave;
            } while (Math.Abs(s) > ERRTOL);
            return w * (1.0 + s * s * (C1 + s * (C2 + s * (C3 + s * C4)))) / Math.Sqrt(ave);
        }

        private double rd(double x, double y, double z)
        {
            double ERRTOL = 0.0015, C1 = 3.0 / 14.0, C2 = 1.0 / 6.0, C3 = 9.0 / 22.0, C4 = 3.0 / 26.0, C5 = 0.25 * C3, C6 = 1.5 * C4;

            double TINY = 2.0 * Math.Pow(double.MaxValue, -2.0 / 3.0), BIG = 0.1 * ERRTOL * Math.Pow(double.MinValue, -2.0 / 3.0);

            double alamb, ave, delx, dely, delz, ea, eb, ec, ed, ee, fac, sqrtx, sqrty, sqrtz, sum, xt, yt, zt;

            if (Math.Min(x, y) < 0.0 || Math.Min(x + y, z) < TINY || Math.Max(Math.Max(x, y), z) > BIG)
                Console.WriteLine("invalid arguments in rd");

            xt = x;
            yt = y;
            zt = z;
            sum = 0.0;
            fac = 1.0;

            do
            {
                sqrtx = Math.Sqrt(xt);
                sqrty = Math.Sqrt(yt);
                sqrtz = Math.Sqrt(zt);
                alamb = sqrtx * (sqrty + sqrtz) + sqrty * sqrtz;
                sum += fac / (sqrtz * (zt + alamb));
                fac = 0.25 * fac;
                xt = 0.25 * (xt + alamb);
                yt = 0.25 * (yt + alamb);
                zt = 0.25 * (zt + alamb);
                ave = 0.2 * (xt + yt + 3.0 * zt);
                delx = (ave - xt) / ave;
                dely = (ave - yt) / ave;
                delz = (ave - zt) / ave;
            } while (Math.Max(Math.Max(Math.Abs(delx), Math.Abs(dely)), Math.Abs(delz)) > ERRTOL);

            ea = delx * dely;
            eb = delz * delz;
            ec = ea - eb;
            ed = ea - 6.0 * eb;
            ee = ed + ec + ec;

            return 3.0 * sum + fac * (1.0 + ed * (-C1 + C5 * ed - C6 * delz * ee) + delz * (C2 * ee + delz * (-C3 * ec + delz * C4 * ea))) / (ave * Math.Sqrt(ave));
        }

        // Computes Carlson's elliptic integral of the first kind, R_F (x, y, z). x, y, z must be nonnegative, and at most one can be zero.
        private double rf(double x, double y, double z)
        {
            double ERRTOL = 0.0025, THIRD = 1.0 / 3.0, C1 = 1.0 / 24.0, C2 = 0.1, C3 = 3.0 / 44.0, C4 = 1.0 / 14.0;

            double TINY = 5.0 * double.MinValue, BIG = 0.2 * double.MaxValue;

            double alamb, ave, delx, dely, delz, e2, e3, sqrtx, sqrty, sqrtz, xt, yt, zt;

            if (Math.Min(Math.Min(x, y), z) < 0.0 || Math.Min(Math.Min(x + y, x + z), y + z) < TINY ||
                Math.Max(Math.Max(x, y), z) > BIG) Console.WriteLine("invalid arguments in rf");

            xt = x;
            yt = y;
            zt = z;

            do
            {
                sqrtx = Math.Sqrt(xt);
                sqrty = Math.Sqrt(yt);
                sqrtz = Math.Sqrt(zt);
                alamb = sqrtx * (sqrty + sqrtz) + sqrty * sqrtz;
                xt = 0.25 * (xt + alamb);
                yt = 0.25 * (yt + alamb);
                zt = 0.25 * (zt + alamb);
                ave = THIRD * (xt + yt + zt);
                delx = (ave - xt) / ave;
                dely = (ave - yt) / ave;
                delz = (ave - zt) / ave;
            } while (Math.Max(Math.Max(Math.Abs(delx), Math.Abs(dely)), Math.Abs(delz)) > ERRTOL);

            e2 = delx * dely - delz * delz;
            e3 = delx * dely * delz;

            return (1.0 + (C1 * e2 - C2 - C3 * e3) * e2 + C4 * e3) / Math.Sqrt(ave);
        }


        private double rj(double x, double y, double z, double p)
        {
            double ERRTOL = 0.0015, C1 = 3.0 / 14.0, C2 = 1.0 / 3.0, C3 = 3.0 / 22.0, C4 = 3.0 / 26.0, C5 = 0.75 * C3, C6 = 1.5 * C4, C7 = 0.5 * C2, C8 = C3 + C3;

            double TINY = Math.Pow(5.0 * double.MinValue, 1.0 / 3.0), BIG = 0.3 * Math.Pow(0.2 * double.MaxValue, 1.0 / 3.0);

            double a = 0;
            double b = 0;
            double rcx = 0;
            double alamb, alpha, ans, ave, beta, delp, delx, dely, delz, ea, eb, ec, ed, ee, fac, pt, rho, sqrtx, sqrty, sqrtz, sum, tau, xt, yt, zt;

            if (Math.Min(Math.Min(x, y), z) < 0.0 || Math.Min(Math.Min(x + y, x + z), Math.Min(y + z, Math.Abs(p))) < TINY
                || Math.Max(Math.Max(x, y), Math.Max(z, Math.Abs(p))) > BIG) Console.WriteLine("invalid arguments in rj");

            sum = 0.0;
            fac = 1.0;
            if (p > 0.0)
            {
                xt = x;
                yt = y;
                zt = z;
                pt = p;
            }
            else
            {
                xt = Math.Min(Math.Min(x, y), z);
                zt = Math.Max(Math.Max(x, y), z);
                yt = x + y + z - xt - zt;
                a = 1.0 / (yt - p);
                b = a * (zt - yt) * (yt - xt);
                pt = yt + b;
                rho = xt * zt / yt;
                tau = p * pt / yt;
                rcx = rc(rho, tau);
            }
            do
            {
                sqrtx = Math.Sqrt(xt);
                sqrty = Math.Sqrt(yt);
                sqrtz = Math.Sqrt(zt);
                alamb = sqrtx * (sqrty + sqrtz) + sqrty * sqrtz;
                alpha = Math.Pow(pt * (sqrtx + sqrty + sqrtz) + sqrtx * sqrty * sqrtz, 2);
                beta = pt * Math.Pow(pt + alamb, 2);
                sum += fac * rc(alpha, beta);
                fac = 0.25 * fac;
                xt = 0.25 * (xt + alamb);
                yt = 0.25 * (yt + alamb);
                zt = 0.25 * (zt + alamb);
                pt = 0.25 * (pt + alamb);
                ave = 0.2 * (xt + yt + zt + pt + pt);
                delx = (ave - xt) / ave;
                dely = (ave - yt) / ave;
                delz = (ave - zt) / ave;
                delp = (ave - pt) / ave;
            } while (Math.Max(Math.Max(Math.Abs(delx), Math.Abs(dely)), Math.Max(Math.Abs(delz), Math.Abs(delp))) > ERRTOL);
            ea = delx * (dely + delz) + dely * delz;
            eb = delx * dely * delz;
            ec = delp * delp;
            ed = ea - 3.0 * ec;
            ee = eb + 2.0 * delp * (ea - ec);
            ans = 3.0 * sum + fac * (1.0 + ed * (-C1 + C5 * ed - C6 * ee) + eb * (C7 + delp * (-C8 + delp * C4)) + delp * ea * (C2 - delp * C3) - C2 * delp * ec) / (ave * Math.Sqrt(ave));

            if (p <= 0.0) ans = a * (b * ans + 3.0 * (rcx - rf(xt, yt, zt)));

            return ans;
        }


        public void sncndn(double uu, double emmc, out double sn, out double cn, out double dn)
        {
            const double CA = 1.0e-8;
            bool bo;
            int i, ii;
            int l = 0;
            double a, b, emc, u;

            double c = 0;
            double d = 0;
            
            double[] em = new double[13];
            double[] en = new double[13];

            emc = emmc;
            u = uu;
            if (emc != 0.0)
            {
                bo = (emc < 0.0);
                if (bo)
                {
                    d = 1.0 - emc;
                    emc /= -1.0 / d;
                    u *= (d = Math.Sqrt(d));
                }
                a = 1.0;
                dn = 1.0;
                for (i = 0; i < 13; i++)
                {
                    l = i;
                    em[i] = a;
                    en[i] = (emc = Math.Sqrt(emc));
                    c = 0.5 * (a + emc);
                    if (Math.Abs(a - emc) <= CA * a) break;
                    emc *= a;
                    a = c;
                }
                u *= c;
                sn = Math.Sin(u);
                cn = Math.Cos(u);
                if (sn != 0.0)
                {
                    a = cn / sn;
                    c *= a;
                    for (ii = l; ii >= 0; ii--)
                    {
                        b = em[ii];
                        a *= c;
                        c *= dn;
                        dn = (en[ii] + a) / (b + a);
                        a = c / b;
                    }
                    a = 1.0 / Math.Sqrt(c * c + 1.0);
                    sn = (sn >= 0.0 ? a : -a);
                    cn = c * sn;
                }
                if (bo)
                {
                    a = dn;
                    dn = cn;
                    cn = a;
                    sn /= d;
                }
            }
            else // if (emc == 0.0)
            {
                cn = 1.0 / Math.Cosh(u);
                dn = cn;
                sn = Math.Tanh(u);
            }
        }

    }
}

