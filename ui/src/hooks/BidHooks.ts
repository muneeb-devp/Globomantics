import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query"
import config from "../config"
import { Bid } from "../types/bid"
import axios, { AxiosError, AxiosResponse } from "axios"
import Problem from "../types/problem"

export const useFetchBids = (houseId: number) => {
  return useQuery<Bid[], AxiosError<Problem>>({
    queryKey: ['bids', houseId],
    queryFn: () => axios.get(`${config.baseUrl}/houses/${houseId}/bids`).then(resp => resp.data)
  })
}

export const useAddBid = () => {
  const queryClient = useQueryClient()

  return useMutation<AxiosResponse, AxiosError<Problem>, Bid>({
    mutationFn: b => axios.post(`${config.baseUrl}/houses/${b.houseId}/bids`, b),
    onSuccess: (resp, bid) => {
      queryClient.invalidateQueries({
        queryKey: ['bids', bid.houseId]
      })
    }
  })
}