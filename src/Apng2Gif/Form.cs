using ImageMagick;
using LibAPNG.WPF;
using System.Drawing;
using System.IO;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Apng2Gif {
	public partial class Form : System.Windows.Forms.Form {
		public Form() {
			InitializeComponent();
		}

		private void OnDragEnter(object sender, DragEventArgs e) {
			if(e.Data?.GetDataPresent(DataFormats.FileDrop) ?? false) {
				if(e.Data?.GetData(DataFormats.FileDrop) is string[] drops) {
					if(drops.All(x => Path.GetExtension(x).ToLower() == ".png")) {
						e.Effect = DragDropEffects.All;
					}
				}
			}
		}

		private void OnDragDrop(object sender, DragEventArgs e) {
			if(e.Data?.GetData(DataFormats.FileDrop) is string[] drops) {
				foreach(var png in drops) {
					try {
						var apng = new LibAPNG.APNG(png);
						if(!apng.IsSimplePNG) {
							using var mg = new MagickImageCollection();
							foreach(var img in apng.ToBitmapSources().Cast<WriteableBitmap>().Select((x, i) => (Image: x, Index: i))) {
								using var ms = new MemoryStream();
								BitmapEncoder enc = new PngBitmapEncoder();
								enc.Frames.Add(BitmapFrame.Create(img.Image));
								enc.Save(ms);
								ms.Position = 0;
								mg.Add(new MagickImage(ms));
								mg[img.Index].AnimationIterations = 0;
								mg[img.Index].AnimationDelay = (int)(apng.Frames[img.Index].fcTLChunk.DelayNum switch {
									0 => 100,
									_ => (double)apng.Frames[img.Index].fcTLChunk.DelayNum / apng.Frames[img.Index].fcTLChunk.DelayDen switch {
										0 => 100,
										var v => v
									} * 100
								});
							}
							mg.Quantize(new QuantizeSettings() {
								Colors = 256
							});
							mg.Optimize();
							mg.Write($"{Path.GetDirectoryName(png)}\\{Path.GetFileNameWithoutExtension(png)}.gif");
						}
					}
					catch(Exception) {
						MessageBox.Show(this, $"èàóùÇ…é∏îs\r\n{png}", "ÉGÉâÅ[", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
	}
}