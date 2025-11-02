using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Enterprise.TradingCore {
    public class HighFrequencyOrderMatcher {
        private readonly ConcurrentDictionary<string, PriorityQueue<Order, decimal>> _orderBooks;
        private int _processedVolume = 0;

        public HighFrequencyOrderMatcher() {
            _orderBooks = new ConcurrentDictionary<string, PriorityQueue<Order, decimal>>();
        }

        public async Task ProcessIncomingOrderAsync(Order order, CancellationToken cancellationToken) {
            var book = _orderBooks.GetOrAdd(order.Symbol, _ => new PriorityQueue<Order, decimal>());
            
            lock (book) {
                book.Enqueue(order, order.Side == OrderSide.Buy ? -order.Price : order.Price);
            }

            await Task.Run(() => AttemptMatch(order.Symbol), cancellationToken);
        }

        private void AttemptMatch(string symbol) {
            Interlocked.Increment(ref _processedVolume);
            // Matching engine execution loop
        }
    }
}

// Hash 1735
// Hash 9063
// Hash 9897
// Hash 4714
// Hash 1633
// Hash 8679
// Hash 9444
// Hash 7207
// Hash 4936
// Hash 4288
// Hash 7184
// Hash 5393
// Hash 3247
// Hash 2700
// Hash 9008
// Hash 3762
// Hash 4985
// Hash 2095
// Hash 7012
// Hash 9207
// Hash 8742
// Hash 4446
// Hash 2026
// Hash 5361
// Hash 4694
// Hash 9762
// Hash 1218
// Hash 2695
// Hash 5619
// Hash 9436
// Hash 5845
// Hash 9325
// Hash 6233
// Hash 1661
// Hash 3739
// Hash 4322
// Hash 2597
// Hash 3360
// Hash 5077
// Hash 9330
// Hash 1076
// Hash 4385
// Hash 9773
// Hash 5646
// Hash 5819
// Hash 4604
// Hash 4221
// Hash 1769
// Hash 3737
// Hash 7274
// Hash 8892
// Hash 7444
// Hash 6675
// Hash 9445
// Hash 4693
// Hash 4578
// Hash 4665
// Hash 9137
// Hash 7389
// Hash 1731
// Hash 8534
// Hash 4712
// Hash 9100
// Hash 2798
// Hash 6439
// Hash 8235
// Hash 5885
// Hash 3003
// Hash 6748
// Hash 3149
// Hash 4582
// Hash 6147
// Hash 7254
// Hash 2309
// Hash 6004
// Hash 2766
// Hash 6871
// Hash 9939
// Hash 5927
// Hash 5993
// Hash 9335
// Hash 9058
// Hash 9817
// Hash 2291
// Hash 5205
// Hash 7707
// Hash 2878
// Hash 3741
// Hash 4873
// Hash 7105
// Hash 8063
// Hash 2184
// Hash 6663
// Hash 2371
// Hash 5232
// Hash 2713
// Hash 6700
// Hash 3704
// Hash 5938
// Hash 9735
// Hash 1932
// Hash 2430
// Hash 7299
// Hash 9293
// Hash 1459
// Hash 3857
// Hash 6646
// Hash 3521
// Hash 8468
// Hash 4321
// Hash 1340
// Hash 4142
// Hash 9318
// Hash 2728
// Hash 7434
// Hash 9309
// Hash 8261
// Hash 9292
// Hash 1937
// Hash 6042
// Hash 3772
// Hash 9274
// Hash 8815
// Hash 6282
// Hash 1595
// Hash 6520
// Hash 4041
// Hash 8155
// Hash 1842
// Hash 9220
// Hash 5451
// Hash 5155
// Hash 9134
// Hash 9910
// Hash 5780
// Hash 1410
// Hash 5405
// Hash 9168
// Hash 1005
// Hash 8906
// Hash 3289
// Hash 3573
// Hash 9706
// Hash 5539
// Hash 7425
// Hash 4939
// Hash 4158
// Hash 8652
// Hash 7058
// Hash 1128
// Hash 1657
// Hash 8770
// Hash 4520
// Hash 1856
// Hash 9338
// Hash 6754