using System;

public class Program
{
    public static void Main()
    {
        Quaternion quaternion = new Quaternion(1, 2, 3, 4);
        Console.WriteLine($"Quaternion: ({quaternion.X}, {quaternion.Y}, {quaternion.Z}, {quaternion.W})");
        double norm = quaternion.Norm();
        Console.WriteLine($"Norm: {norm}");
        Quaternion conjugate = quaternion.Conjugate();
        Console.WriteLine($"Conjugate: ({conjugate.X}, {conjugate.Y}, {conjugate.Z}, {conjugate.W})");
        Quaternion inverse = quaternion.Inverse();
        Console.WriteLine($"Inverse: ({inverse.X}, {inverse.Y}, {inverse.Z}, {inverse.W})");
        Matrix3x3 rotationMatrix = new Matrix3x3();
        double[,] matrixData = { { 0.866, -0.5, 0 }, { 0.5, 0.866, 0 }, { 0, 0, 1 } };
        rotationMatrix.Fill(matrixData);
        Quaternion fromMatrix = Quaternion.FromRotationMatrix(rotationMatrix);
        Console.WriteLine($"Quaternion from rotation matrix: ({fromMatrix.X}, {fromMatrix.Y}, {fromMatrix.Z}, {fromMatrix.W})");
    }
}

public class Matrix3x3
{
    public void Fill(double[,] matrixData)
    {
        throw new NotImplementedException();
    }
}

public class Quaternion
{
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }
    public double W { get; private set; }

    public Quaternion(double x, double y, double z, double w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public static Quaternion operator +(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.X + q2.X, q1.Y + q2.Y, q1.Z + q2.Z, q1.W + q2.W);
    }

    public static Quaternion operator -(Quaternion q1, Quaternion q2)
    {
        return new Quaternion(q1.X - q2.X, q1.Y - q2.Y, q1.Z - q2.Z, q1.W - q2.W);
    }

    public static Quaternion operator *(Quaternion q1, Quaternion q2)
    {
        double x = q1.W * q2.X + q1.X * q2.W + q1.Y * q2.Z - q1.Z * q2.Y;
        double y = q1.W * q2.Y - q1.X * q2.Z + q1.Y * q2.W + q1.Z * q2.X;
        double z = q1.W * q2.Z + q1.X * q2.Y - q1.Y * q2.X + q1.Z * q2.W;
        double w = q1.W * q2.W - q1.X * q2.X - q1.Y * q2.Y - q1.Z * q2.Z;

        return new Quaternion(x, y, z, w);
    }

    public double Norm()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
    }

    public Quaternion Conjugate()
    {
        return new Quaternion(-X, -Y, -Z, W);
    }

    public Quaternion Inverse()
    {
        double normSquared = X * X + Y * Y + Z * Z + W * W;
        if (normSquared == 0)
        {
            throw new InvalidOperationException("Quaternion has zero norm, cannot invert.");
        }

        double inverseNorm = 1 / normSquared;
        return new Quaternion(-X * inverseNorm, -Y * inverseNorm, -Z * inverseNorm, W * inverseNorm);
    }

    public static bool operator ==(Quaternion q1, Quaternion q2)
    {
        return q1.X == q2.X && q1.Y == q2.Y && q1.Z == q2.Z && q1.W == q2.W;
    }

    public static bool operator !=(Quaternion q1, Quaternion q2)
    {
        return !(q1 == q2);
    }


    public static Quaternion FromRotationMatrix(Matrix3x3 rotationMatrix)
    {
        throw new NotImplementedException();
    }
}
