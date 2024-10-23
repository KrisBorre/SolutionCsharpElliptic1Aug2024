namespace LibraryEllipticIntegrals20dec2023
{
    public class EllipticIntegralK_20dec2023 : FunctionAbstractClass20dec2023
    {
        EllipticIntegralCalculator20dec2023 ellipticIntegralCalculator20Dec2023;

        /// <summary>
        /// Elliptic integral of the first kind
        /// </summary>
        public EllipticIntegralK_20dec2023(EllipticIntegralCalculator20dec2023 ellipticIntegralCalculator20Dec2023)
        {
            this.ellipticIntegralCalculator20Dec2023 = ellipticIntegralCalculator20Dec2023 ?? new EllipticIntegralCalculator20dec2023();
        }

        /// <summary>
        /// Elliptic integral of the first kind
        /// </summary>
        public override double Function(double k)
        {
            return this.ellipticIntegralCalculator20Dec2023.ellf(Math.PI / 2.0, k);
        }

        public override double Derivative(double k)
        {
            EllipticIntegralE_20dec2023 ellipticIntegralE_20Dec2023 = new EllipticIntegralE_20dec2023(this.ellipticIntegralCalculator20Dec2023);
            double ellipticIntegralE = ellipticIntegralE_20Dec2023.Function(k);
            return (ellipticIntegralE / (k * (1 - k * k))) - (this.Function(k) / k);
        }
    }
}
