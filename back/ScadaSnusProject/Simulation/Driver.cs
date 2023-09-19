namespace ScadaSnusProject.Simulation;

public class Driver
{
    public double Sin()
    {
        double amplitude = 100;
        double frequency = 0.01;
        double time = DateTime.Now.TimeOfDay.TotalSeconds;
        double angle = 2 * Math.PI * frequency * time;
        double value = amplitude * Math.Sin(angle);
        return value;
    }

    public double Cos()
    {
        double amplitude = 100;
        double frequency = 0.01;
        double time = DateTime.Now.TimeOfDay.TotalSeconds;
        double angle = 2 * Math.PI * frequency * time;
        double value = amplitude * Math.Sin(angle);
        return value;
    }
}