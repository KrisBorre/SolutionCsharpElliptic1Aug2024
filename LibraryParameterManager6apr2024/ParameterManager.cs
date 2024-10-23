using System.Numerics;

namespace LibraryParameterManager6apr2024
{
    public abstract class ParameterManager<T>
         where T : INumber<T>
    {
        private ParameterConfiguration parameter_configuration;

        protected ParameterConfiguration ParameterConfiguration
        {
            get { return parameter_configuration; }
            private set { parameter_configuration = value; }
        }

        protected ParameterManager(ParameterConfiguration parameter_configuration = ParameterConfiguration.Constant)
        {
            this.parameter_configuration = parameter_configuration;
        }

        protected T GetParameter(T interval, T t)
        {
            T parameter = T.CreateChecked(1.0);

            if (parameter_configuration == ParameterConfiguration.Increase)
            {
                if (t <= T.CreateChecked(10.0))
                {
                    parameter = T.CreateChecked(1.0);
                }
                if ((t > T.CreateChecked(10.0)) && (t <= (interval / T.CreateChecked(2.0) - T.CreateChecked(5.0))))
                {
                    T m = T.CreateChecked(4.0) / (interval / T.CreateChecked(2.0) - T.CreateChecked(15.0));
                    T q = T.CreateChecked(1) - (T.CreateChecked(40.0) / (interval / T.CreateChecked(2.0) - T.CreateChecked(15.0)));
                    parameter = m * t + q;
                }
                if ((t > (interval / T.CreateChecked(2.0) - T.CreateChecked(5.0))) && (t <= (interval / T.CreateChecked(2.0) + T.CreateChecked(5.0))))
                {
                    parameter = T.CreateChecked(5.0);
                }
                if ((t > (interval / T.CreateChecked(2.0) + T.CreateChecked(5.0))) && (t <= (interval - T.CreateChecked(10.0))))
                {
                    T m = T.CreateChecked(-4.0) / (interval / T.CreateChecked(2.0) - T.CreateChecked(15.0));
                    T q = T.CreateChecked(1.0) - m * (interval - T.CreateChecked(10.0));
                    parameter = m * t + q;
                }
                if ((t > (interval - T.CreateChecked(10.0))) && (t <= interval))
                {
                    parameter = T.CreateChecked(1.0);
                }
            }

            if (parameter_configuration == ParameterConfiguration.Decrease)
            {
                if (t <= T.CreateChecked(10.0))
                {
                    parameter = T.CreateChecked(5.0);
                }
                if ((t > T.CreateChecked(10.0)) && (t <= (interval / T.CreateChecked(2.0) - T.CreateChecked(5.0))))
                {
                    T m = T.CreateChecked(-4.0) / ((interval / T.CreateChecked(2.0)) - T.CreateChecked(15.0));
                    T q = T.CreateChecked(5) - (T.CreateChecked(-40.0) / ((interval / T.CreateChecked(2.0)) - T.CreateChecked(15.0)));
                    parameter = m * t + q;
                }
                if ((t > (interval / T.CreateChecked(2.0) - T.CreateChecked(5.0))) && (t <= (interval / T.CreateChecked(2.0) + T.CreateChecked(5.0))))
                {
                    parameter = T.CreateChecked(1.0);
                }
                if ((t > (interval / T.CreateChecked(2.0) + T.CreateChecked(5.0))) && (t <= (interval - T.CreateChecked(10.0))))
                {
                    T m = T.CreateChecked(4.0) / (interval / T.CreateChecked(2) - T.CreateChecked(15.0));
                    T q = T.CreateChecked(1) - (T.CreateChecked(4.0) / (interval / T.CreateChecked(2) - T.CreateChecked(15.0))) * (interval / T.CreateChecked(2.0) + T.CreateChecked(5.0));
                    parameter = m * t + q;
                }
                if ((t > (interval - T.CreateChecked(10.0))) && (t <= interval))
                {
                    parameter = T.CreateChecked(5.0);
                }
            }

            return parameter;
        }
    }
}
