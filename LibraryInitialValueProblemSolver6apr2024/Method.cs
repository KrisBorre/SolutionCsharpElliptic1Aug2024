namespace LibraryInitialValueProblemSolver6apr2024
{
    // https://www.dotnetperls.com/enum-flags
    [Flags]
    public enum Method
    {
        Euler = 0x1,
        RK21 = 0x2,
        RK22 = 0x4,
        RK31 = 0x8,
        RK41 = 0x10,
        RK42 = 0x20,
        RK5 = 0x40,
        RK61 = 0x80,
        RKCV8 = 0x100,
        Crude = 0x200,
        Sophisticated = 0x400 // Next three values could be 0x800, 0x1000, 0x2000
    }
}
