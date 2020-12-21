public static class GlobalParams
{
    public static int RUN_TYPE { get; set; } = Constants.RUN_ON_ATTENTION;
    public static int GAME_MODE { get; set; } = Constants.GAME_MODE_EASY;
    public static void Initialize(int run_type, int game_mode)
    {
        RUN_TYPE = run_type;
        GAME_MODE = game_mode;
    }
}
