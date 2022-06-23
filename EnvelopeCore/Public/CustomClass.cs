namespace Public
{
    public class CustomClass
    {

    }

    public class ApiResult
    {
        /// <summary>
        /// 返回结果，True成功、False失败
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object? Data { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string? Message { get; set; }

    }
}