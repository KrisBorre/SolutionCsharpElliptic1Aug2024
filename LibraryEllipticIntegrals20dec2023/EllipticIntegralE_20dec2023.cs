namespace LibraryEllipticIntegrals20dec2023
{
    public class EllipticIntegralE_20dec2023 : FunctionAbstractClass20dec2023
    {
        EllipticIntegralCalculator20dec2023 ellipticIntegralCalculator20Dec2023;

        /// <summary>
        /// Elliptic integral of the second kind
        /// </summary>
        public EllipticIntegralE_20dec2023(EllipticIntegralCalculator20dec2023 ellipticIntegralCalculator20Dec2023)
        {
            this.ellipticIntegralCalculator20Dec2023 = ellipticIntegralCalculator20Dec2023 ?? new EllipticIntegralCalculator20dec2023();
        }

        /// <summary>
        /// Elliptic integral of the second kind
        /// </summary>
        public override double Function(double k)
        {
            return this.ellipticIntegralCalculator20Dec2023.elle(Math.PI / 2.0, k);
        }

        public override double Derivative(double k)
        {
            EllipticIntegralK_20dec2023 ellipticIntegralK_20Dec2023 = new EllipticIntegralK_20dec2023(this.ellipticIntegralCalculator20Dec2023);
            double ellipticIntegralK = ellipticIntegralK_20Dec2023.Function(k);
            return (this.Function(k) - ellipticIntegralK) / k;
        }
    }
}
