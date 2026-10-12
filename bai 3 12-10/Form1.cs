using System.Diagnostics;

namespace bai_3_12_10
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch;
        private CancellationTokenSource cancellationTokenSource;

        public Form1()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Simulate a long-running database operation with progress reporting
        /// </summary>
        private async Task SimulateTaskAsync(IProgress<int> progress, CancellationToken cancellationToken)
        {
            // Simulate 10 steps, each taking 500ms
            int totalSteps = 10;
            int delayPerStep = 500; // milliseconds

            for (int i = 0; i < totalSteps; i++)
            {
                // Check if cancellation was requested
                cancellationToken.ThrowIfCancellationRequested();

                // Simulate long-running work on background thread
                await Task.Run(() => 
                {
                    Thread.Sleep(delayPerStep);
                }, cancellationToken);

                // Calculate progress percentage (0-100)
                int progressPercentage = (int)((i + 1) / (double)totalSteps * 100);

                // Report progress back to UI thread
                progress.Report(progressPercentage);
            }
        }

        /// <summary>
        /// Event handler for the Start Task button
        /// </summary>
        private async void BtnStartTask_Click(object sender, EventArgs e)
        {
            // Disable button during operation
            btnStartTask.Enabled = false;
            lblStatus.Text = "Trạng thái: Đang xử lý...";
            lblStatus.ForeColor = Color.Blue;

            // Reset progress bars
            progressBar1.Value = 0;
            toolStripProgressBar.Value = 0;

            // Start stopwatch to measure execution time
            stopwatch.Restart();

            // Create cancellation token source
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                // Create IProgress object to report progress
                var progress = new Progress<int>(progressValue =>
                {
                    // This callback executes on UI thread
                    progressBar1.Value = progressValue;
                    toolStripProgressBar.Value = progressValue;
                    toolStripStatusLabel1.Text = $"Tiến trình: {progressValue}% - Thời gian: {stopwatch.ElapsedMilliseconds}ms";
                    lblStatus.Text = $"Trạng thái: Đang xử lý... {progressValue}%";
                });

                // Execute async operation
                await SimulateTaskAsync(progress, cancellationTokenSource.Token);

                // All completed successfully
                stopwatch.Stop();
                lblStatus.Text = "Trạng thái: Hoàn thành";
                lblStatus.ForeColor = Color.Green;
                lblElapsedTime.Text = $"Thời gian: {stopwatch.ElapsedMilliseconds}ms";
                toolStripStatusLabel1.Text = $"Hoàn thành - Thời gian: {stopwatch.ElapsedMilliseconds}ms";

                MessageBox.Show($"Tác vụ hoàn thành!\nThời gian thực hiện: {stopwatch.ElapsedMilliseconds}ms", 
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                stopwatch.Stop();
                lblStatus.Text = "Trạng thái: Đã hủy";
                lblStatus.ForeColor = Color.Orange;
                toolStripStatusLabel1.Text = "Tác vụ đã bị hủy";
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                lblStatus.Text = "Trạng thái: Lỗi";
                lblStatus.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "Lỗi xảy ra";
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", 
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Re-enable button after operation completes
                btnStartTask.Enabled = true;
                cancellationTokenSource?.Dispose();
            }
        }
    }
}
