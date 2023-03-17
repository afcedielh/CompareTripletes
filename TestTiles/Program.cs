class Result
{

    /*
     * Complete the 'compareTriplets' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static List<int> CompareTriplets(List<int> a, List<int> b)
    {
        List<int> ret = new(){
            0,0
        };
        for (int i = 0; i <= 2; i++)
        {
            ret[0] = ret[0] + (a[i] > b[i] ? 1 : 0);
            ret[1] = ret[1] + (b[i] > a[i] ? 1 : 0);
        }
        return ret;
    }

}

class Solution
{
    public static void Main()
    {       
        List<int> a = new() { 5, 6, 7 };
        List<int> b = new() { 3, 6, 10 };
        _ = Result.CompareTriplets(a, b);
    }
}